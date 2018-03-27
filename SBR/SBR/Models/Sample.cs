using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SBR.Models
{
   public partial class Sample
    {
       
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("character")]
            public string Character { get; set; }

            [JsonProperty("episode")]
            public string Episode { get; set; }

            [JsonProperty("file")]
            public string File { get; set; }

            public string ImageCharacter
            {
                get
                {
                    return Character.ToLower().Trim().Replace("é", "e").Replace("è", "e").Replace("ê", "e").Replace("Ï", "i").Replace("'", "").Replace(" ","").Replace("î","i").Replace("'","");
                }
            }

            public override string ToString()
            {
                return Title + " - " + Character;
            }
        }
    
    
}
