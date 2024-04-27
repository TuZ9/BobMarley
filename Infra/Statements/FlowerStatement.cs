using System.Diagnostics.CodeAnalysis;

namespace BobMarley.Infra.Statements
{
    [ExcludeFromCodeCoverage]
    internal static class FlowerStatement
    {
        internal const string GetFlower = "SELECT * FROM TB_FLOWER;";

        internal const string DeleteFlower = "DELETE FROM public.Flower AS tgt USING SOURCE_TABLE AS src WHERE tgt.id_flower=src.id_flower;";

        internal const string InsertFlower = @"INSERT INTO public.Flower
                                              (name, type, description, qr, url, image, labtest, thc, cbd, createdat, updatedat, id_brand, id_strain, id_flower)
                                              VALUES('', '', '', '', '', '', false, false, false, '', '', ?, ?, ?);";

        internal const string UpdateFlower = @"UPDATE public.Flower
                                              SET 
                                              name='', type='', description='', qr='', url='', image='', labtest=false, 
                                              thc=false, cbd=false, createdat='', updatedat='', id_brand=?, id_strain=?
                                              WHERE id_flower=?;";
    }
}