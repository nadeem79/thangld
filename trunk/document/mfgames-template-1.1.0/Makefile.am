AUTOMAKE_OPTIONS=dist-bzip2 dist-zip
BUILD = $(top_builddir)/build
DOCBOOK_XSL = /usr/share/xml/docbook/stylesheet/nwalsh/xhtml/docbook.xsl
DOCBOOK_HTML_PARAMS = --stringparam html.stylesheet style.css

mfgames_template_ASSEMBLY_NAME = MfGames.Template
mfgames_template_DLL = $(mfgames_template_ASSEMBLY_NAME).dll
mfgames_template_ASSEMBLY = $(BUILD)/$(mfgames_template_DLL)
mfgames_template_SOURCES =  \
src/TemplateFactory.cs \
src/AssemblyInfo.cs \
src/TemplateBase.cs \
src/Context.cs \
src/ITemplate.cs \
src/TemplateManager.cs \
src/TemplateException.cs

test_DLL = test.dll
test_ASSEMBLY = $(BUILD)/$(test_DLL)
test_SOURCES = \
src/test/TemplateTest.cs

tool_NAME = mfgames-template.exe
tool_EXE = $(BUILD)/$(tool_NAME)
tool_SOURCES = \
src/tool/ToolEntry.cs \
src/tool/PrecompileTool.cs

# Generic
all: $(mfgames_template_ASSEMBLY) $(tool_EXE) $(test_ASSEMBLY) docs

clean-local:
	$(RM) -rf $(BUILD)
	$(RM) -f *~ */*~ */*/*~

$(mfgames_template_ASSEMBLY): $(mfgames_template_SOURCES)
	mkdir -p $(BUILD)
	$(CSC) $(CSC_FLAGS) -target:library -out:$@ \
		-keyfile:etc/MfGames.Template.snk \
		-doc:$(BUILD)/MfGames.Template.xml \
		@MFGAMES_UTILITY_LIBS@ \
		$(realpath $(mfgames_template_SOURCES))

$(tool_EXE): $(tool_SOURCES) $(mfgames_template_ASSEMBLY)
	$(CSC) $(CSC_FLAGS) -target:exe -out:$@ \
		@MFGAMES_UTILITY_LIBS@ \
		-r:$(mfgames_template_ASSEMBLY) \
		$(realpath $(tool_SOURCES))

$(test_ASSEMBLY): $(test_SOURCES) $(mfgames_template_ASSEMBLY)
	$(CSC) $(CSC_FLAGS) -target:library -out:$@ \
		@nunit_LIBS@ \
		-r:$(mfgames_template_ASSEMBLY) \
		@MFGAMES_UTILITY_LIBS@ \
		$(realpath $(test_SOURCES))
#	Delete the file if the nunit fails
	@NUNIT_CONSOLE@ /nologo $@ || rm $(test_ASSEMBLY)

#
# Documentation
#

docs: $(BUILD)/index.html $(BUILD)/style.css

$(BUILD)/index.html: docs/mfgames-template.xml
	mkdir -p $(BUILD)
	@XSLTPROC@ $(DOCBOOK_HTML_PARAMS) $(DOCBOOK_XSL) \
		docs/mfgames-template.xml > $(BUILD)/index.html

$(BUILD)/style.css: docs/style.css
	mkdir -p $(BUILD)
	cp docs/style.css $(BUILD)/style.css

# pkgconfig
pkgconfig_in_files = etc/mfgames-template-1.0.pc.in
pkgconfigdir= $(prefix)/lib/pkgconfig
pkgconfig_DATA = $(pkgconfig_in_files:.pc.in=.pc)

# Installation
install-data-local:
	@GACUTIL@ /i $(mfgames_template_ASSEMBLY) /f @GACUTIL_FLAGS@

# Uninstallation
uninstall-local:
	@GACUTIL@ /u $(mfgames_template_ASSEMBLY_NAME) @GACUTIL_FLAGS@

# Definition of the various files that need to be cleaned up properly.
CLEANFILES = $(BUILD)/index.html $(BUILD)/style.css \
	$(BUILD)/MfGames.Template.xml

EXTRA_DIST = $(pkgconfig_in_files) etc/MfGames.Template.snk
EXTRA_DIST += $(mfgames_template_SOURCES)
EXTRA_DIST += $(test_SOURCES)
EXTRA_DIST += docs/mfgames-template.xml docs/style.css
EXTRA_DIST += vc7.1

DISTCLEANFILES = etc/mfgames-template-1.pc

# Debian
dist-debian:
	rm -rf tmp
	mkdir tmp
	-cp -ra * tmp 2> /dev/null
	find tmp -name .svn -o -name config.log -o -name config.status \
		| xargs rm -rf
	cd tmp && debuild
	mv *.dsc *.build *.changes *.deb *.tar.gz ..
	rm -rf tmp
