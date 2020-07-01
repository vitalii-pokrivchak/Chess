using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebChess.Pages
{
    public class ChessModel : PageModel
    {
        public void OnGet()
        {

        }

        class moveData
        {
            public int row { get; set; }
            public int column { get; set; }
            public int destinationRow { get; set; }
            public int destinationColumn { get; set; }
        }

        public async Task OnPostMove(string row,string column,string destinationRow, string destinationColumn)
        {
            MemoryStream stream = new MemoryStream();
            await Request.Body.CopyToAsync(stream);
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream))
            {
                string requestBody = reader.ReadToEnd();
                if (requestBody.Length > 0)
                {
                    var obj = JsonConvert.DeserializeObject<moveData>(requestBody);
                    var col = obj.column;

                }
            }

            var a = 10;
        }
    }
}