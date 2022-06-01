
namespace Project.Model.Models
{
  public class Category : BaseEntity
  {
    public string      Name          { get; set; }
    public int         SubCategoryId { get; set; }
    public SubCategory SubCategory   { get; set; }
  }
}
