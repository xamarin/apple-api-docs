# Xamarin Apple API docs

This repository contains the source of the Xamarin API documentation for native functions in Apple operating systems:

- iOS
- macOS
- tvOS
- watchOS

An example URL to start browsing is http://docs.microsoft.com/dotnet/api/uikit

## Microsoft Open Source Code of Conduct

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Style guidelines

All Xamarin Apple API docs are written in the [indicative mood](https://grammarist.com/grammar/english-moods/). For instance, instead of saying "You call this function to foo the bar," the docs should be "The developer calls this function to foo the bar." The agents we refer to are typically "the developer," "the method" (or "the object"), "the framework," and "the system" (meaning the underlying operating system or hardware services). The indicative mood often takes a little time to get used to, but it helps avoid ambiguity about responsibilities and cuts down on the temptation to use passive voice. 

API docs are divided between `summary` and `remarks` elements. Summaries are displayed in IntelliSense and should be quite short (perhaps around 140 characters, certainly fewer than 250). If there is a numeric value with an underlying unit-of-measure, include the unit in the summary (e.g., "The angle, in radians," or "the distance, in meters"). 

Summaries may contain tags, but should not wrap their content in another tag:

- Right: `<summary>Foos the <paramref name="bar"/>.</summary>` 
- Wrong: `<summary><para>Foos the <paramref name="bar"/>.</para></summary>`

## Scripts included in the repository

- **make all**: run xmllint with the bundled monodoc-ecma.xsl to
   verify the syntax of the documentation in the repository

## Using DocWriter

Use github.com/xamarin/DocWriter to author documentation.

## Troubleshooting

In case macdoc blows up when trying to load the documentation or you can't compile the docs or similar check for:

- **busted index.xml**: run the above `missing` script which will
    give you the entry in the xml that are not present in the
    filesystem

- **parse error**: run `make all` to check for syntax errors in the
    documentation files

## Using MacDoc?

Run macdoc by passing the absolute path to the en/ directory
(i.e. where the index.xml file is) preprended with the character '+'.

    ./macdoc.app/Contents/MacOS/macdoc '+/path/to/ios-api-docs/en/'

You need a recent macdoc. You can compile it yourself by cloning
https://github.com/mono/monomac and running the build process
there. Macdoc is under the samples directory.

This repository is also submoduled by XamarinVS to fetch the baseline docs from where MSXML docs are generated and later merged with iOS docs on the user's machine.

## Viewing history?

On January 22, 2018, commits 542f219f and ce6f06729 renamed the directories from, e.g., `en/MonoTouch.UIKit` to `en/UIKit`. In almost all cases `git log {type.xml}` will track back only to these commits. To track past those commits, use:

    git log --follow --find-copies-harder --find-renames=40 {type.xml}
    
Lowering the `find-renames` threshold to around 40 seems to work   in almost all cases. You can try lower thresholds, although at some point you could presumably start triggering incorrect matches. 

## Legal Notices

Microsoft and any contributors grant you a license to the Microsoft documentation and other content
in this repository under the [Creative Commons Attribution 4.0 International Public License](https://creativecommons.org/licenses/by/4.0/legalcode),
see the [LICENSE](LICENSE) file, and grant you a license to any code in the repository under the [MIT License](https://opensource.org/licenses/MIT), see the
[LICENSE-CODE](LICENSE-CODE) file.

Microsoft, Windows, Microsoft Azure and/or other Microsoft products and services referenced in the documentation
may be either trademarks or registered trademarks of Microsoft in the United States and/or other countries.
The licenses for this project do not grant you rights to use any Microsoft names, logos, or trademarks.
Microsoft's general trademark guidelines can be found at http://go.microsoft.com/fwlink/?LinkID=254653.

Privacy information can be found at https://privacy.microsoft.com/en-us/

Microsoft and any contributors reserve all others rights, whether under their respective copyrights, patents,
or trademarks, whether by implication, estoppel or otherwise.
