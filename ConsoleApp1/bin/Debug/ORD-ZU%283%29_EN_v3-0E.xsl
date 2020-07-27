<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:zzu="http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2018/08/24/eD/ORDZU/" xmlns:etd="http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2018/08/24/eD/DefinicjeTypy/" xmlns:xs="http://www.w3.org/2001/XMLSchema">
	<xsl:import href="http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2018/09/03/eD/DefinicjeSzablony/WspolneSzablonyWizualizacjiEN_v4-0E.xsl"/>
	<xsl:output method="html" encoding="UTF-8" indent="yes" version="4.01" doctype-public="-//W3C//DTD HTML 4.01//EN" doctype-system="http://www.w3.org/TR/html4/strict.dtd"/>
	<xsl:template match="zzu:Zalacznik_ORD-ZU">
		<div class="zalacznik">
			<xsl:call-template name="NaglowekTechniczny">
				<xsl:with-param name="uzycie" select="'zalacznik'"/>
				<xsl:with-param name="naglowek" select="zzu:Naglowek"/>
				<xsl:with-param name="alternatywny-naglowek" select="ancestor::*[local-name()='Deklaracja']/*[local-name()='Naglowek']"/>
			</xsl:call-template>
			<xsl:call-template name="NaglowekTytulowyZalacznikIFT">
				<xsl:with-param name="uzycie" select="'zalacznik'"/>
				<xsl:with-param name="naglowek" select="ancestor::*[local-name()='Deklaracja']/*[local-name()='Naglowek']"/>
				<xsl:with-param name="nazwa">UZASADNIENIE PRZYCZYN KOREKTY DEKLARACJI<br/>
					<span class="ang">[The explanation of the reasons of correction]</span>
				</xsl:with-param>
			</xsl:call-template>
			<xsl:for-each select="ancestor::*[local-name()='Deklaracja']/*[local-name()='Podmiot1']">
				<xsl:call-template name="Podmiot">
					<xsl:with-param name="sekcja">A.</xsl:with-param>
					<xsl:with-param name="pokazuj-adres" select="false()"/>
					<xsl:with-param name="pokazuj-tytul" select="false()"/>
				</xsl:call-template>
			</xsl:for-each>
			<xsl:for-each select="ancestor::*[local-name()='Deklaracja']/*[local-name()='Podmiot2']">
				<xsl:call-template name="Podmiot2ORDZU">
					<xsl:with-param name="sekcja">B.</xsl:with-param>
				</xsl:call-template>
			</xsl:for-each>
			<xsl:call-template name="Uzasadnienie"/>
		</div>
	</xsl:template>
	<xsl:template name="Podmiot2ORDZU">
		<xsl:param name="sekcja"/>
		<h2 class="tytul-sekcja-blok">
			<xsl:value-of select="$sekcja"/>&#xA0;DANE ODBIORCY&#xA0;<span class="ang">[IDENTIFICATION DATA OF RECIPIENT]</span>
		</h2>
		<xsl:if test="*[local-name()='OsobaFizZagr']/*[local-name()='NIP']|*[local-name()='OsobaNieFizZagr']/*[local-name()='NIP']">
			<table class="normalna">
				<tr>
					<td class="wypelniane">
						<div class="opisrubryki">Identyfikator podatkowy NIP&#xA0;<span class="ang">[Tax Identification Number NIP]</span>
						</div>
						<xsl:apply-templates select="*[local-name()='OsobaFizZagr']/*[local-name()='NIP']"/>
						<xsl:apply-templates select="*[local-name()='OsobaNieFizZagr']/*[local-name()='NIP']"/>
					</td>
				</tr>
			</table>
		</xsl:if>
		<table class="normalna">
			<tr>
				<td class="wypelniane">
					<div class="opisrubryki">Nazwisko / Nazwa pełna&#xA0;<span class="ang">[Family name /Full name]</span>
					</div>
					<xsl:apply-templates select="*[local-name()='OsobaFizZagr']/*[local-name()='Nazwisko']"/>
					<xsl:apply-templates select="*[local-name()='OsobaNieFizZagr']/*[local-name()='PelnaNazwa']"/>
				</td>
			</tr>
			<tr>
				<td class="wypelniane">
					<div class="opisrubryki">Pierwsze imię / Nazwa skrócona&#xA0;<span class="ang">[First name /Short name]</span>
					</div>
					<xsl:apply-templates select="*[local-name()='OsobaFizZagr']/*[local-name()='ImiePierwsze']"/>
					<xsl:apply-templates select="*[local-name()='OsobaNieFizZagr']/*[local-name()='SkroconaNazwa']"/>
				</td>
			</tr>
		</table>
		<table class="normalna">
			<tr>
				<td class="wypelniane" style="width: 50%">
					<div class="opisrubryki">Imię ojca&#xA0;<span class="ang">[Father's name]</span>
					</div>
					<xsl:apply-templates select="*[local-name()='OsobaFizZagr']/*[local-name()='ImieOjca']"/>
				</td>
				<td class="wypelniane" style="width: 50%">
					<div class="opisrubryki">Imię matki&#xA0;<span class="ang">[Mother's name]</span>
					</div>
					<xsl:apply-templates select="*[local-name()='OsobaFizZagr']/*[local-name()='ImieMatki']"/>
				</td>
			</tr>
		</table>
		<table class="normalna">
			<tr>
				<td class="wypelniane">
					<div class="opisrubryki">Data urodzenia / Data rozpoczęcia działalności&#xA0;<span class="ang">[Date of birth /Foundation date]</span>
					</div>
					<xsl:apply-templates select="*[local-name()='OsobaFizZagr']/*[local-name()='DataUrodzenia']"/>
					<xsl:apply-templates select="*[local-name()='OsobaNieFizZagr']/*[local-name()='DataRozpoczeciaDzialalnosci']"/>
				</td>
			</tr>
		</table>
	</xsl:template>
	<xsl:template name="Uzasadnienie">
		<xsl:for-each select="zzu:PozycjeSzczegolowe">
			<table class="normalna">
				<tr>
					<td style="width: 100%">
						<div class="opis-tekstowy">13. Treść uzasadnienia&#xA0;<span class="ang">[The explanation]</span>
						</div>
						<div>
							<xsl:value-of select="zzu:P_13"/>
						</div>
					</td>
				</tr>
			</table>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>
