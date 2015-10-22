
MDOC=/Library/Frameworks/Mono.framework/Commands/mdoc

all:
	@echo validating...
	@mdoc assemble -o MonoTouch-lib en
	@echo success

validate:
	@echo Validating....
	xmllint --noout --schema monodoc-ecma.xsd en/*/*.xml 2>&1 | grep -v validates
	@echo success

TOP := $(shell pwd)

#view:
#	git submodule update --init --recursive
#	$(MAKE) -C external/monomac/samples/macdoc macdoc
#	cd external/monomac/samples/macdoc/bin/Debug && ./macdoc.app/Contents/MacOS/macdoc @"$(TOP)/en"

install:
	$(MDOC) assemble -o MonoTouch-lib en
	cp MonoTouch-lib.{tree,zip} /Library/Frameworks/Mono.framework/External/monodoc/

fixdos:
	git status | grep modified  | awk '{print $$3}' | xargs perl -pi -e 's/\r\n/\n/g'
