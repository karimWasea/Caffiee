﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAcessLayers
{
 
   public class CategoryAttachment
    {
        public int Id { get; set; }
        public string FilePath { get; set; } // Path to the file
        public string FileType { get; set; } // MIME type of the file
        public int ProductId { get; set; }
        public Category Category { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;

    }


}