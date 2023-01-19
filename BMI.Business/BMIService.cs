using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BMIIndex.Data;

namespace BMI.Business
{
    public class BMIService  
    {
        private static List<BMIndex> list = new List<BMIndex>();

        public static void SaveBMI(BMIndex b)
        {
            GetBMIList();
            list.Add(b); 

            string json=JsonSerializer.Serialize(list,new JsonSerializerOptions { IncludeFields=true});
            FileOperations.Write(json);  
        }
        public static IReadOnlyCollection<BMIndex> GetBMIList()
        {
            string json = FileOperations.Read();

            if (json != "")
            {
                list = JsonSerializer.Deserialize<List<BMIndex>>(json, new JsonSerializerOptions { IncludeFields = true });
            }

            return list.AsReadOnly();       //I dont want to changing from UI layer

        }

        public static IReadOnlyCollection <BMIndex> SearchPatientFromList(string searched)
        {
            GetBMIList();
            var result=list.Where(q => q.name==searched).ToList();     //where is a filter key 
            return result.AsReadOnly();
        }
        // var sonuc = (from q in list
        //           where q.ad == ad     // different way for searching      
        //         select q).ToList();


        //var sonuc = new List<VKI>();
        //foreach(var item in list)
        //{
        //  if (item.ad == ad) 
        //    sonuc.Add(item);        // 2.different way for searching
        //}

         public static void DeletePatientFromList(string deleted)
         {
            
            list = list.Where(q => q.name != deleted).ToList();     //where is a filter key 
            string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { IncludeFields = true });
            FileOperations.Write(json);
        }
       
    }
}
