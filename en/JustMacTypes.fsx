open System.IO
open System.Diagnostics
#r "System.Core.dll"
#r "System.Xml"
#r "System.Xml.Linq"

open System
open System.Linq
open System.Xml.Linq
open System.Xml
open System.IO
open System.Text
open System.IO

let xn s = XName.Get(s)

let baseDir = "."

let allFileNames : string seq = seq { for f in Directory.EnumerateFiles(baseDir , "*.xml", SearchOption.AllDirectories) do yield f }

let allXDocs = seq { for s in allFileNames do yield (s, (XDocument.Load(s))) }

let allTypeDocs = allXDocs |> Seq.filter (fun (_, d) -> d.Root.Name = xn "Type") 

let query (doc : XDocument) = 
    let asms = doc.Root.Element(xn "AssemblyInfo").Elements(xn "AssemblyName") 
    let isMacType = asms |> Seq.exists (fun an -> an.Value = "Xamarin.Mac")
    let isIosType = asms |> Seq.exists (fun an -> an.Value = "Xamarin.iOS")
    isMacType && not isIosType

let isDeprecated (doc : XDocument) = 
    let attNames = doc.Root.Elements(xn "Attributes") |> Seq.collect (fun atts -> atts.Elements(xn "Attribute")) |> Seq.map (fun att -> att.Element(xn "AttributeName"))
    attNames |> Seq.exists (fun an -> an.Value.Contains("Deprecated"))

allTypeDocs 
|> Seq.filter (fun (_, d) -> query d )
|> Seq.map (fun (p, d) -> (p, isDeprecated d))
|> Seq.iter (fun (p, isDeprecated) -> printfn "%s, %b" p isDeprecated |> ignore )