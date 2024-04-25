
namespace BobMarley.Infra.Statements
{
    internal static class FlowerStatement
    {
        public static string GetFlower = "SELECT * FROM TB_FLOWER;";

        public static string DeleteFlower = "DELETE FROM public.Flower AS tgt USING SOURCE_TABLE AS src WHERE tgt.id_flower=src.id_flower;";

        public static string InsertFlower = @"INSERT INTO public.Flower
                                              (name, type, description, qr, url, image, labtest, thc, cbd, createdat, updatedat, id_brand, id_strain, id_flower)
                                              VALUES('', '', '', '', '', '', false, false, false, '', '', ?, ?, ?);";

        public static string UpdateFlower = @"UPDATE public.Flower
                                              SET 
                                              name='', type='', description='', qr='', url='', image='', labtest=false, 
                                              thc=false, cbd=false, createdat='', updatedat='', id_brand=?, id_strain=?
                                              WHERE id_flower=?;";
    }
}