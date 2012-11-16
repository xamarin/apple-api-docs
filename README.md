Monotouch API docs
==========

This repository contains the source of the MonoTouch API documentation
to be edited.

Scripts included in the repository
----------

  - **missing**: a C# script (execute directly or run with `csharp`)

  - **make all**: run xmllint with the bundled monodoc-ecma.xsl to
      verify the syntax of the documentation in the repository

Visualizing the documentation with macdoc
----------

Run macdoc by passing the absolute path to the en/ directory
(i.e. where the index.xml file is) preprended with the character '+'.

    ./macdoc.app/Contents/MacOS/macdoc '+/path/to/ios-api-docs/en/'

You need a recent macdoc. You can compile it yourself by cloning
https://github.com/mono/monomac and running the build process
there. Macdoc is under the samples directory.

Unbreaking list
----------

In case macdoc blows up when trying to load the documentation or you can't compile the docs or similar check for:

  - **busted index.xml**: run the above `missing` script which will
      give you the entry in the xml that are not present in the
      filesystem

  - **parse error**: run `make all` to check for syntax errors in the
      documentation files
