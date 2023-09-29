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
    
    public ActionResult<List<Cadete>> GetCadetes(){
        var cadetes = cadeteria.DevolverCadetes();
        return Ok(cadetes);
    }
    // [Get] GetInforme() => Retorna un objeto Informe

    // [Post] AgregarPedido(Pedido pedido)
    [HttpPost]
    public ActionResult<Pedido> AgregarPedido(Pedido pedido){
        var nuevoPedido = cadeteria.AgregarPedido(pedido);
        return Ok(nuevoPedido);
    }
    // [Put] AsignarPedido(int idPedido, int idCadete)
    [HttpPut] //Poner nombre
    public ActionResult<Pedido> AsignarPedido(int idPedido, int idCadete){
        var nuevoPedido = cadeteria.AsignarCadeteAPedido(idCadete, idPedido);
        return Ok(nuevoPedido);
    }
    // [Put] CambiarEstadoPedido(int idPedido,int NuevoEstado)
    [HttpPut]
    public ActionResult<Pedido> CambiarEstadoPedido(int idPedido, Estado nuevoEstado){
        var nuevoPedido = cadeteria.CambiarEstadoDePedido(idPedido, nuevoEstado);
        return Ok(nuevoPedido);
    }
    // [Put] CambiarCadetePedido(int idPedido,int idNuevoCadete)
    [HttpPut]
    public ActionResult<Pedido> CambiarCadetePedido(int idPedido, int idNuevoCadete){
        var nuevoPedido = cadeteria.ReasignarPedido(idPedido, idNuevoCadete);
        return Ok(nuevoPedido);
    }
}