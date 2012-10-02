all:
	@echo validating...
	@mdoc assemble -o MonoTouch-lib en
	@echo success

validate:
	@echo Validating....
	xmllint --noout --schema monodoc-ecma.xsd en/*/*.xml 2>&1 | grep -v validates
	@echo success
