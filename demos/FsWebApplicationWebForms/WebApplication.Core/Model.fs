namespace WebApplication.Core

open Microsoft.FSharp.Quotations
open Microsoft.FSharp.Linq
open Microsoft.FSharp.Linq.Query

open WebApplication.Data

type ProductInfo = {
  ID : int
  Name : string
  Category : string
  Price : System.Decimal }

module Model = 
  let ListProducts (ordering:Expr<Product -> 'T>) =
    let dx = new NorthwindDataContext()
    <@ seq { for p in dx.Products |> Seq.sortBy %ordering do
                for c in dx.Categories do
                  if (p.CategoryID.Value = c.CategoryID) then
                    yield { ID = p.ProductID
                            Name = p.ProductName 
                            Category = c.CategoryName 
                            Price = p.UnitPrice.Value } } @> |> query

  let ProductDetail (id) =
    let dx = new NorthwindDataContext()
    <@ seq { for p in dx.Products do
               if (p.ProductID = id) then yield p }
         |> Seq.head @> |> query
