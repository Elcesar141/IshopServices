namespace Catalog.API.Exepcion
{
    public class ProductNotFoundExepction : Exception
    {
        public ProductNotFoundExepction():base("Producto no encontrado")
        {

        }
    }
}
