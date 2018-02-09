#r "System.Xml"
#r "System.Xml.Linq"

open System
open System.Linq
open System.Xml.Linq
open System.IO

let xn s = XName.Get(s)

let baseDir = "."

let AllDirectories = 
   seq { for d in Directory.EnumerateDirectories(baseDir) do yield d } 
   |> Seq.map (fun s -> s.Substring(2)) // Remove "./" that begins all
   |> List.ofSeq 
   |> Set.ofList

let AllNamespaceNames = 
   let doc = XDocument.Load("index.xml")
   let nss = doc.Descendants(xn "Namespace") |> Seq.map (fun el -> el.Attribute(xn "Name").Value)
   seq { for ns in nss do yield ns } |> List.ofSeq |> Set.ofList

printfn "Comparing the set of directory names with the Namespace elements in index.xml"

let dirsThatAreNotInIndexXml = AllDirectories - AllNamespaceNames 

dirsThatAreNotInIndexXml |> Seq.iter (fun d -> printfn "Directory '%s' not found in index.xml" d)

let nsEntriesThatDoNotHaveCorrespondingDirs = AllNamespaceNames - AllDirectories

nsEntriesThatDoNotHaveCorrespondingDirs |> Seq.iter (fun ns -> printfn "Namespace '%s' does not have corresponding directory" ns)

printfn "Finished"


