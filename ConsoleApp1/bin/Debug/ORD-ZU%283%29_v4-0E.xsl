<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:zzu="http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2018/08/24/eD/ORDZU/">
	<xsl:import href="http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2018/09/03/eD/DefinicjeSzablony/WspolneSzablonyWizualizacji_v7-0E.xsl"/>
	<xsl:output method="html" encoding="UTF-8" indent="yes" version="4.01" doctype-public="-//W3C//DTD HTML 4.01//EN" doctype-system="http://www.w3.org/TR/html4/strict.dtd"/>
	<xsl:template match="zzu:Zalacznik_ORD-ZU">
		<div class="zalacznik">
			<xsl:call-template name="NaglowekTechniczny">
				<xsl:with-param name="uzycie" select="'zalacznik'"/>
				<xsl:with-param name="naglowek" select="zzu:Naglowek"/>
				<xsl:with-param name="alternatywny-naglowek" select="ancestor::*[local-name()='Deklaracja']/*[local-name()='Naglowek']"/>
			</xsl:call-template>
			<xsl:call-template name="NaglowekTytulowy">
				<xsl:with-param name="uzycie" select="'zalacznik'"/>
				<xsl:with-param name="nazwa">UZASADNIENIE PRZYCZYN KOREKTY DEKLARACJI</xsl:with-param>
				<xsl:with-param name="naglowek" select="ancestor::*[local-name()='Deklaracja']/*[local-name()='Naglowek']"/>
			</xsl:call-template>
			<xsl:for-each select="ancestor::*[local-name()='Deklaracja']/*[local-name()='Podmiot1']">
				<xsl:call-template name="Podmiot">
					<xsl:with-param name="sekcja">A. </xsl:with-param>
					<xsl:with-param name="pokazuj-adres" select="false()"/>
				</xsl:call-template>
			</xsl:for-each>
			<xsl:for-each select="ancestor::*[local-name()='Deklaracja']/*[local-name()='Podmiot2']">
				<xsl:call-template name="Podmiot">
					<xsl:with-param name="sekcja">B. </xsl:with-param>
					<xsl:with-param name="pokazuj-adres" select="false()"/>
				</xsl:call-template>
			</xsl:for-each>
			<xsl:call-template name="Uzasadnienie"/>
		</div>
		<!-- zalacznik -->
	</xsl:template>
	<xsl:template name="Uzasadnienie">
		<xsl:for-each select="zzu:PozycjeSzczegolowe">
			<table class="normalna">
				<tr>
					<td style="width: 100%">
						<div class="opis-tekstowy">13. Treść uzasadnienia</div>
						<div>
							<xsl:value-of select="zzu:P_13"/>
						</div>
					</td>
				</tr>
			</table>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>
