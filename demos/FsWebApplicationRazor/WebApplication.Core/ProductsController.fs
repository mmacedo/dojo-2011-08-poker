namespace WebApplication.Core.Controllers

open System
open System.Web.Mvc

open WebApplication.Data
open WebApplication.Core

[<HandleError>]
type ProductsController() =
  inherit Controller()
  
  let (|NonNull|_|) (a:Nullable<_>) =
    if a.HasValue then Some(a.Value) else None

  member x.List(id:Nullable<int>) =
    x.ViewData.Model <- 
      match id with
      | NonNull(1) -> Model.ListProducts <@ fun p -> p.UnitPrice.Value @>
      | NonNull(2) -> Model.ListProducts <@ fun p -> p.CategoryID.Value @>
      | _ -> Model.ListProducts <@ fun p -> p.ProductName @>
    x.View() 

  member x.Detail(id:int) =
    x.ViewData.Model <- Model.ProductDetail id
    x.View() 
