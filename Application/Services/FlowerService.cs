using BobMarley.Domain.Interfaces.ApiClientService;
using BobMarley.Domain.Interfaces.Repositories;
using BobMarley.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using BobMarley.Domain.Dto;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using static OpenAI_API.Chat.ChatMessage;
using AutoMapper;
using BobMarley.Domain.Entities;

namespace BobMarley.Application.Services
{
    public class FlowerService : IFlowerService
    {
        private readonly ILogger<FlowerService> _logger;
        private readonly IFlowerRepository _flowerRepository;
        private readonly IFlowerApiClient _flowerApiClient;
        private readonly IMapper _mapper;
        public FlowerService(ILogger<FlowerService> logger, IFlowerRepository flowerRepository, IFlowerApiClient flowerApiClient, IMapper mapper)
        {
            _logger = logger;
            _flowerRepository = flowerRepository;
            _flowerApiClient = flowerApiClient;
            _mapper = mapper;
        }
        public async Task BuildBase()
        {
            try
            {
                var lisfFlower = new List<FlowerDto>();
                for (int i = 0; i <= 101; i++)
                {
                    var flowers = await _flowerApiClient.GetAsync($"/v1/flowers?page={i}&count=50");
                    if (flowers.data.Count != 0 || flowers != null)
                    {                        
                        lisfFlower.AddRange(flowers.data);
                        var f = _mapper.ProjectTo<Flower>(lisfFlower.AsQueryable());
                        var a = 0;
                        //Mapp para Entities
                        //tratar Query de insert
                        //inserir 
                        //limpar lista
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public async Task RunGpt4()
        {
            OpenAIAPI api = new OpenAIAPI("sk-None-zEvDAdW2BkGhlHV9GW05T3BlbkFJ8DdBHtuHQYU10MXyGH60");

            var chat = api.Chat.CreateConversation();
            chat.AppendUserInput("How to make a hamburger?");

            await foreach (var res in chat.StreamResponseEnumerableFromChatbotAsync())
            {
                Console.Write(res);
            }
            // the simplest form
            var result = await api.Chat.CreateChatCompletionAsync("What is the primary non-white color in this logo?", ImageInput.FromFile("path/to/logo.png"));

            // or in a conversation
            //var chat = api.Chat.CreateConversation();
            chat.Model = Model.GPT4_Vision;
            chat.AppendSystemMessage("You are a graphic design assistant who helps identify colors.");
            chat.AppendUserInput("What are the primary non-white colors in this logo?", ImageInput.FromFile("path/to/logo.png"));
            string response = await chat.GetResponseFromChatbotAsync();
            Console.WriteLine(response); // "Blue and purple"
            chat.AppendUserInput("What are the primary non-white colors in this logo?", ImageInput.FromImageUrl("https://rogerpincombe.com/templates/rp/center-aligned-no-shadow-small.png"));
            response = await chat.GetResponseFromChatbotAsync();
            Console.WriteLine(response); // "Blue, red, and yellow"

            // or when manually creating the ChatMessage
            //messageWithImage = new ChatMessage(ChatMessageRole.User, "What colors do these logos have in common?");
            //messageWithImage.images.Add(ImageInput.FromFile("path/to/logo.png"));
            //messageWithImage.images.Add(ImageInput.FromImageUrl("https://rogerpincombe.com/templates/rp/center-aligned-no-shadow-small.png"));

            // you can specify multiple images at once
            chat.AppendUserInput("What colors do these logos have in common?", ImageInput.FromFile("path/to/logo.png"), ImageInput.FromImageUrl("https://rogerpincombe.com/templates/rp/center-aligned-no-shadow-small.png"));
        }

        public async Task RunGpt()
        {
            //OpenAIAPI api = new OpenAIAPI("sk-None-zEvDAdW2BkGhlHV9GW05T3BlbkFJ8DdBHtuHQYU10MXyGH60");
            OpenAIAPI api = new OpenAIAPI(new APIAuthentication("sk-None-zEvDAdW2BkGhlHV9GW05T3BlbkFJ8DdBHtuHQYU10MXyGH60"));
            var chat = api.Chat.CreateConversation();
            chat.Model = Model.ChatGPTTurbo;
            chat.RequestParameters.Temperature = 0;

            ///// give instruction as System
            //chat.AppendSystemMessage("You are a teacher who helps children understand if things are animals or not.  If the user tells you an animal, you say \"yes\".  If the user tells you something that is not an animal, you say \"no\".  You only ever respond with \"yes\" or \"no\".  You do not say anything else.");

            //// give a few examples as user and assistant
            //chat.AppendUserInput("Is this an animal? Cat");
            //chat.AppendExampleChatbotOutput("Yes");
            //chat.AppendUserInput("Is this an animal? House");
            //chat.AppendExampleChatbotOutput("No");

            //// now let's ask it a question
            //chat.AppendUserInput("Is this an animal? Dog");
            //// and get the response
            //string response = await chat.GetResponseFromChatbotAsync();
            //Console.WriteLine(response); // "Yes"

            //// and continue the conversation by asking another
            //chat.AppendUserInput("Is this an animal? Chair");
            //// and get another response
            //response = await chat.GetResponseFromChatbotAsync();
            //Console.WriteLine(response); // "No"

            chat.AppendUserInput("How to make a hamburger?");

            await foreach (var res in chat.StreamResponseEnumerableFromChatbotAsync())
            {
                Console.Write(res);
            }

            // the entire chat history is available in chat.Messages
            foreach (ChatMessage msg in chat.Messages)
            {
                Console.WriteLine($"{msg.Role}: {msg.Content}");
            }


            chat.OnTruncationNeeded += (sender, args) =>
            {
                // args is a List<ChatMessage> with the current chat history.  Remove or edit as nessisary.
                // replace this with more sophisticated logic for your use-case, such as summarizing the chat history
                for (int i = 0; i < args.Count; i++)
                {
                    if (args[i].Role != ChatMessageRole.System)
                    {
                        args.RemoveAt(i);
                        return;
                    }
                }
            };
        }
    }
}
