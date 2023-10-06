using EspacioCadeteria;
using EspacioCadete;
using EspacioPedido;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp4_2023_LucianoCV01.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase{
    private Cadeteria cadeteria;
    private readonly ILogger<CadeteriaController> _logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        cadeteria = Cadeteria.GetCadeteria();
    }

    // [Get] GetPedidos() => Retorna una lista de Pedidos
    [HttpGet]
    public ActionResult<List<Pedido>> GetPedidos(){
        var pedidos = cadeteria.DevolverPedidos();
        return Ok(pedidos);
    }
    // [Get] GetCadetes() => Retorna una lista de Cadetes
    [HttpGet]
    [Route("GetCadetes")]
    public ActionResult<List<Cadete>> GetCadetes(){
        var cadetes = cadeteria.DevolverCadetes();
        return Ok(cadetes);
    }
    // [Get] GetInforme() => Retorna un objeto Informe

    // [Get] GetPedido/{id} : devuelve un pedido especificado por el id
    [HttpGet]
    [Route("GetPedidoId")]
    public ActionResult<Pedido> GetPedidoId(int idPedido){
        Pedido buscado = cadeteria.BuscarPedido(idPedido);
        return Ok(buscado);
    }
    // [Get] GetCadete/{id} : devuelve un cadete especificado por el id
    [HttpGet]
    [Route("GetCadeteId")]
    public ActionResult<Cadete> GetCadeteId(int idCadete){
        Cadete buscado = cadeteria.BuscarCadete(idCadete);
        return Ok(buscado);
    }
    // [Post] AgregarPedido(Pedido pedido)
    [HttpPost("AgregarPedido")]
    public ActionResult<Pedido> AgregarPedido(Pedido pedido){
        var nuevoPedido = cadeteria.AgregarPedido(pedido);
        return Ok(nuevoPedido);
    }
    // [Post] AddCadete : agrega un cadete nuevo a la cadetería.
    [HttpPost("AgregarCadete")]
    public ActionResult<Cadete> AgregarCadete(Cadete cadete){
        var nuevoCadete = cadeteria.AgregarCadete(cadete);
        return Ok(nuevoCadete);
    }
    // [Put] AsignarPedido(int idPedido, int idCadete)
    [HttpPut("AsignarPedido")]
    public ActionResult<Pedido> AsignarPedido(int idPedido, int idCadete){
        var nuevoPedido = cadeteria.AsignarCadeteAPedido(idCadete, idPedido);
        return Ok(nuevoPedido);
    }
    // [Put] CambiarEstadoPedido(int idPedido,int NuevoEstado)
    [HttpPut("CambiarEstadoPedido")]
    public ActionResult<Pedido> CambiarEstadoPedido(int idPedido, Estado nuevoEstado){
        var nuevoPedido = cadeteria.CambiarEstadoDePedido(idPedido, nuevoEstado);
        return Ok(nuevoPedido);
    }
    // [Put] CambiarCadetePedido(int idPedido,int idNuevoCadete)
    [HttpPut("CambiarCadetePedido")]
    public ActionResult<Pedido> CambiarCadetePedido(int idPedido, int idNuevoCadete){
        var nuevoPedido = cadeteria.ReasignarPedido(idPedido, idNuevoCadete);
        return Ok(nuevoPedido);
    }

}