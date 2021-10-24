using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Inquilino
{
    public class GridModel : PageModel
    {
        private readonly ITipoInquilinoService tipoInquilinoService;

        public GridModel(ITipoInquilinoService tipoInquilinoService)
        {
            this.tipoInquilinoService = tipoInquilinoService;
        }

        public IEnumerable<TipoInquilinoEntity> GridList { get; set; } = new List<TipoInquilinoEntity>();

        public string Mensaje { get; set; } = "";
        public async Task<ActionResult> OnGet()
        {
            try
            {
                GridList = await tipoInquilinoService.Get();

                if (TempData.ContainsKey(key: "Msg"))
                {
                    Mensaje = TempData[key: "Msg"] as string;
                }

                TempData.Clear();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }

        }


        public async Task<ActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await tipoInquilinoService.Delete(entity: new() { Id_TipoInquilino = id });

                if (result.CodeError!=0)
                {
                    throw new Exception(message: result.MsgError);
                }

                TempData[key: "Msg"] = "Se Elimino Correctamente";

                return Redirect(url:"Grid");
            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }

        }
    }
}
