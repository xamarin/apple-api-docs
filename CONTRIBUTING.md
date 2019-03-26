# Contributing
---

We welcome contributions to this repository! 

Please note the [code of conduct](CODE_OF_CONDUCT.md) we require contributors to follow. 

## How Can I Contribute?

[Raise an issue!](./issues): The easiest way to help us is just to let us know where we need to do some work. 

Make a change yourself: We love pull-requests!

## Working with EcmaDoc XML

The content of the `Docs` elements (`summary` and `remarks` elements) are the place for writing. The XML is based on [the definition at this page](http://docs.go-mono.com/index.aspx?link=man:mdoc(5)).

* Namespace level docs: Edit the ns-{Namespace}.xml file in the docs/ directory. 
* Type level docs: Every public class has a corresponding {Type}.xml file. The type-level documentation goes into `Docs` element that is a child of the `Type` element. 
* Member level docs: Within the {Type}.xml file, every member has a `Type/Members/Member` element, each of which contains a `Docs` element. 

Within the `Docs` elements, you will likely be editing one or more of the following: 

* `param`: Describes the associated method argument. 
* `value`: Describes the value returned by the member.
* `summary`: A short description, as seen in IntelliSense. Generally less than 150 characters. 
* `remarks`: More substantive reference documentation, often including a short code snippet demonstrating use.

These elements all accept mixed content (text and XML). The [mdoc reference page](http://docs.go-mono.com/index.aspx?link=man:mdoc(5) describes the structure of the XML. 

## Cross-References

To link to other API documentation, you must use the 

     <see cref="{TargetTypeIndicator}:{FullyQualifiedName}"/>

element, _not_ an HTML-style link. 

`{TargetTypeIndicator}` is one of: 

      'C' // Constructor
      'E' // Event
      'F' // Field
      'M' // Method 
      'N' // Namespace
      'P' // Property
      'T' // Type 
      
Note that the fully-qualified name of a method does not include  parentheses if there are no arguments, but if there are, the argument types must be fully-qualified as well:

    M:UIKit.UIView.MovedToWindow  // No parentheses
    M:UIKit.UIView.InsertSubview(UIKit.UIView,System.nint) //Fully-qualified types of arguments

