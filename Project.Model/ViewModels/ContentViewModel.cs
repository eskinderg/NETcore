//using System.Runtime.Serialization;
using Project.Model.Models;

namespace Project.Model.ViewModels
{
    //[DataContract]
    public class ContentViewModel 
    {
        //[DataMember]
        public int Id { get; set; }

        //[DataMember]
        public string Title { get; set; }

        //[DataMember]
        public string Summary { get; set; }

        //[DataMember]
        public int XmlConfigId { get; set; }

        //[DataMember]
        public int FolderId { get; set; }

        //[DataMember]
        public Folder Folder { get; set; }
    }
}
