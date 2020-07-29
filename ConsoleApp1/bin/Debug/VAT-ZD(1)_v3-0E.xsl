<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:vzd="http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2019/02/07/eD/VATZD/">
	<xsl:import href="http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2018/09/03/eD/DefinicjeSzablony/WspolneSzablonyWizualizacji_v7-0E.xsl"/>
	<xsl:output method="html" encoding="UTF-8" indent="yes" version="4.01" doctype-public="-//W3C//DTD HTML 4.01//EN" doctype-system="http://www.w3.org/TR/html4/strict.dtd"/>
	<xsl:template match="vzd:Wniosek_VAT-ZD">
		<div class="zalacznik">
			<xsl:call-template name="NaglowekTechniczny">
				<xsl:with-param name="uzycie" select="'zalacznik'"/>
				<xsl:with-param name="naglowek" select="vzd:Naglowek"/>
				<xsl:with-param name="alternatywny-naglowek" select="ancestor::*[local-name()='Deklaracja']/*[local-name()='Naglowek']"/>
			</xsl:call-template>
			<xsl:call-template name="NaglowekTytulowy">
				<xsl:with-param name="uzycie" select="'zalacznik'"/>
				<xsl:with-param name="naglowek" select="ancestor::*[local-name()='Deklaracja']/*[local-name()='Naglowek']"/>
				<xsl:with-param name="nazwa">ZAWIADOMIENIE O SKORYGOWANIU PODSTAWY OPODATKOWANIA ORAZ KWOTY PODATKU NALEŻNEGO</xsl:with-param>
				<xsl:with-param name="podstawy-prawne">
					<table class="normalna">
						<tr>
							<td>Załącznik do deklaracji dla podatku od towarów i usług: VAT-7, VAT-7K.</td>
						</tr>
					</table>
					<table>
						<tr>
							<td class="etykieta">Podstawa prawna:</td>
							<td class="wartosc">Art. 89a ust. 5 ustawy z dnia 11 marca 2004 r. o podatku od towarów i usług (Dz. U. z 2018 r. poz. 2174, z późn. zm.), zwanej dalej „ustawą”.</td>
						</tr>
						<tr>
							<td class="etykieta" valign="top">Składający:</td>
							<td class="wartosc">Podatnik (wierzyciel) dokonujący korekty podstawy opodatkowania oraz kwoty podatku należnego, o której mowa w art. 89a ust. 1.</td>
						</tr>
						<tr>
							<td class="etykieta">Termin składania:</td>
							<td class="wartosc">W terminie złożenia deklaracji podatkowej, w której podatnik dokonuje korekty, o której mowa w art. 89a ust. 1 ustawy.</td>
						</tr>
						<tr>
							<td class="etykieta" valign="top">Miejsce składania:</td>
							<td class="wartosc">Urząd skarbowy właściwy dla podatnika (wierzyciela).
						</td>
						</tr>
					</table>
				</xsl:with-param>
			</xsl:call-template>
			<xsl:for-each select="ancestor::*[local-name()='Deklaracja']/*[local-name()='Podmiot1']">
				<xsl:call-template name="Podmiot">
					<xsl:with-param name="sekcja">A.</xsl:with-param>
					<xsl:with-param name="pokazuj-adres" select="false()"/>
				</xsl:call-template>
			</xsl:for-each>
			<xsl:call-template name="TrescWnioskuZD">
				<xsl:with-param name="sekcja">B.</xsl:with-param>
			</xsl:call-template>
		</div>
	</xsl:template>
	<xsl:template name="TrescWnioskuZD">
		<xsl:param name="sekcja"/>
		<h2 class="tytul-sekcja-blok">
			<xsl:value-of select="$sekcja"/>&#xA0;DANE IDENTYFIKACYJNE DŁUŻNIKA ORAZ INFORMACJE DOTYCZĄCE KWOT KOREKT PODSTAWY OPODATKOWANIA ORAZ PODATKU NALEŻNEGO</h2>
		<table class="normalna">
			<td class="niewypelniane" style="width: 3%">Lp.</td>
			<td class="niewypelniane" style="width: 27%">Nazwa podatnika (dłużnika)</td>
			<td class="niewypelniane" style="width: 10%">Identyfikator podatkowy NIP podatnika (dłużnika)</td>
			<td class="niewypelniane" style="width:15%">
Nr faktury<hr/>
Data wystawienia faktury</td>
			<td class="niewypelniane" style="width: 15%">Data upływu terminu płatności</td>
			<td class="niewypelniane" style="width: 15%">Kwota korekty podstawy opodatkowania</td>
			<td class="niewypelniane" style="width: 15%">Kwota korekty podatku należnego</td>
			<tr>
				<td class="niewypelniane">a</td>
				<td class="niewypelniane">b</td>
				<td class="niewypelniane">c</td>
				<td class="niewypelniane">d</td>
				<td class="niewypelniane">e</td>
				<td class="niewypelniane">f</td>
				<td class="niewypelniane">g</td>
			</tr>
			<xsl:for-each select="vzd:PozycjeSzczegolowe/vzd:P_B">
				<tr>
					<td class="niewypelniane">
						<xsl:number/>
					</td>
					<td class="wypelniane">
						<div class="kwota">
							<xsl:value-of select="vzd:P_BB"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="kwota">
							<xsl:value-of select="vzd:P_BC"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="kwota">
							<xsl:value-of select="vzd:P_BD1"/>
							<hr/>
							<xsl:value-of select="vzd:P_BD2"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="kwota">
							<xsl:value-of select="vzd:P_BE"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="kwota">
							<xsl:value-of select="vzd:P_BF"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="kwota">
							<xsl:value-of select="vzd:P_BG"/>
						</div>
					</td>
				</tr>
			</xsl:for-each>
		</table>
		<table class="normalna">
			<xsl:for-each select="vzd:PozycjeSzczegolowe">
				<tr>
					<td class="niewypelniane" style="width:70%">
						<div>Ogółem kwoty</div>
					</td>
					<td class="wypelniane" style="width:15%">
						<div class="opisrubryki">10.</div>
						<div class="kwota">
							<xsl:value-of select="vzd:P_10"/>
						</div>
					</td>
					<td class="wypelniane" style="width:15%">
						<div class="opisrubryki">11.</div>
						<div class="kwota">
							<xsl:value-of select="vzd:P_11"/>
						</div>
					</td>
				</tr>
			</xsl:for-each>
		</table>
	</xsl:template>
</xsl:stylesheet>
