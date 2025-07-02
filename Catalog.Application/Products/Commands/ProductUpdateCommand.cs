namespace Catalog.Application.Products.Commands;

public class ProductUpdateCommand : ProductCommand
{
    // I could use a primary constructor here, but I need to allow PUT with JSON body
    // PUT with JSON body requires the ID to be settable
    public int Id { get; set; }
}
