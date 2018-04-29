namespace Project.Model.Models
{
    
    public class Content : BaseEntity
    {

        public string Title { get; set; }
        
        public string Html { get; set; }
        
        public string Summary { get; set; }
        
        public int XmlConfigId { get; set; }
        
        public int FolderId { get; set; }
        
        public virtual Folder Folder { get; set; }

    }
}
