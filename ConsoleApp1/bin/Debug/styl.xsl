<?xml version="1.0" encoding="UTF-8"?><xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:pf="http://crd.gov.pl/wzor/2019/11/08/8836/" version="1.0">
	<xsl:import href="http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2018/09/03/eD/DefinicjeSzablony/Posredni_wspolne_v7-0E.xsl"/>
	<xsl:import href="http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2019/02/07/eD/VATZD/VAT-ZD(1)_v3-0E.xsl"/>
	<xsl:import href="http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2018/08/24/eD/ORDZU/ORD-ZU(3)_v4-0E.xsl"/>
	<xsl:output method="html" encoding="UTF-8" indent="yes" version="4.01" doctype-public="-//W3C//DTD HTML 4.01//EN" doctype-system="http://www.w3.org/TR/html4/strict.dtd"/>
	<xsl:param name="nazwy-dla-kodow" select="true()"/>
	<xsl:template name="TytulDokumentu">DEKLARACJA DLA PODATKU OD TOWARÓW I USŁUG</xsl:template>
	<xsl:template name="StyleDlaFormularza">
		<style type="text/css">
			.tlo-formularza { background-color:#D3D3D3; }
		</style>
	</xsl:template>
	<xsl:template match="pf:Deklaracja">
		<div class="deklaracja">
			<xsl:call-template name="NaglowekTechniczny">
				<xsl:with-param name="naglowek" select="pf:Naglowek"/>
				<xsl:with-param name="uzycie" select="'deklaracja'"/>
			</xsl:call-template>
			<xsl:call-template name="NaglowekTytulowy">
				<xsl:with-param name="naglowek" select="pf:Naglowek"/>
				<xsl:with-param name="uzycie" select="'deklaracja'"/>
				<xsl:with-param name="nazwa">DEKLARACJA DLA PODATKU OD TOWARÓW I USŁUG<br/>ZA</xsl:with-param>
				<xsl:with-param name="objasnienie">
				</xsl:with-param>
				<xsl:with-param name="podstawy-prawne">
					<table>
						<tr>
							<td class="etykieta">Podstawa prawna:</td>
							<td class="wartosc">Art. 99 ust. 1 ustawy z dnia 11 marca 2004 r. o podatku od towarów i usług (Dz. U. z 2018 r. poz. 2174, z późn. zm.), zwanej dalej „ustawą”.</td>
						</tr>
						<tr>
							<td class="etykieta" valign="top">Składający:</td>
							<td class="wartosc">Podatnicy, o których mowa w art. 15 ustawy, obowiązani do składania deklaracji za okresy miesięczne zgodnie z art. 99 ust. 1 ustawy.</td>
						</tr>
					</table>
				</xsl:with-param>
			</xsl:call-template>
			<xsl:call-template name="MiejsceICel">
				<xsl:with-param name="sekcja">A.</xsl:with-param>
			</xsl:call-template>
			<xsl:for-each select="pf:Podmiot1">
				<xsl:call-template name="Podmiot">
					<xsl:with-param name="sekcja">B.</xsl:with-param>
				</xsl:call-template>
			</xsl:for-each>
			<!-- Pozycje Szczegolowe -->
			<xsl:call-template name="RozliczeniePodatkuNaleznego">
				<xsl:with-param name="sekcja">C.</xsl:with-param>
			</xsl:call-template>
			<xsl:call-template name="RozliczeniePodatkuNaliczonego">
				<xsl:with-param name="sekcja">D.</xsl:with-param>
			</xsl:call-template>
			<xsl:call-template name="ObliczenieZobowiązania">
				<xsl:with-param name="sekcja">E.</xsl:with-param>
			</xsl:call-template>
			<xsl:call-template name="InformacjeDodatkowe">
				<xsl:with-param name="sekcja">F.</xsl:with-param>
			</xsl:call-template>
			<xsl:call-template name="InformacjaOZalaczniku">
				<xsl:with-param name="sekcja">G.</xsl:with-param>
			</xsl:call-template>
			<xsl:call-template name="TelefoniData">
				<xsl:with-param name="sekcja">H.</xsl:with-param>
			</xsl:call-template>
			<xsl:call-template name="PouczeniaKoncowe">
			</xsl:call-template>
		</div>
		<!-- deklaracja-->
		<xsl:apply-templates select="pf:Zalaczniki"/>
	</xsl:template>
	<xsl:template name="RozliczeniePodatkuNaleznego">
		<xsl:param name="sekcja"/>
		<xsl:for-each select="pf:PozycjeSzczegolowe">
			<h2 class="tytul-sekcja-blok">
				<xsl:value-of select="$sekcja"/> ROZLICZENIE PODATKU NALEŻNEGO</h2>
			<table class="normalna">
				<td class="puste" style="width: 50%"/>
				<td class="niewypelniane" style="width:25%">Podstawa opodatkowania w zł</td>
				<td class="niewypelniane" style="width:25%">Podatek należny w zł</td>
				<tr>
					<td class="niewypelnianeopisy">1. Dostawa towarów oraz świadczenie usług na terytorium kraju, zwolnione od podatku</td>
					<td class="wypelniane">
						<div class="opisrubryki">10.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_10"/>
						</div>
					</td>
					<td class="puste"/>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">2. Dostawa towarów oraz świadczenie usług poza terytorium kraju</td>
					<td class="wypelniane">
						<div class="opisrubryki">11.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_11"/>
						</div>
					</td>
					<td class="puste"/>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">    2a. w tym świadczenie usług, o których mowa w art. 100 ust. 1 pkt 4 ustawy</td>
					<td class="wypelniane">
						<div class="opisrubryki">12.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_12"/>
						</div>
					</td>
					<td class="puste"/>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">3. Dostawa towarów oraz świadczenie usług, na terytorium kraju, opodatkowane stawką 0%</td>
					<td class="wypelniane">
						<div class="opisrubryki">13.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_13"/>
						</div>
					</td>
					<td class="puste"/>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">   3a. w tym dostawa towarów, o której mowa w art. 129 ustawy</td>
					<td class="wypelniane">
						<div class="opisrubryki">14.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_14"/>
						</div>
					</td>
					<td class="puste"/>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">4. Dostawa towarów oraz świadczenie usług na terytorium kraju, opodatkowane stawką 5%</td>
					<td class="wypelniane">
						<div class="opisrubryki">15.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_15"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="opisrubryki">16.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_16"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">5. Dostawa towarów oraz świadczenie usług na terytorium kraju, opodatkowane stawką 7% albo 8%</td>
					<td class="wypelniane">
						<div class="opisrubryki">17.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_17"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="opisrubryki">18.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_18"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">6. Dostawa towarów oraz świadczenie usług, na terytorium kraju, opodatkowane stawką 22% albo 23%</td>
					<td class="wypelniane">
						<div class="opisrubryki">19.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_19"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="opisrubryki">20.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_20"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">7. Wewnątrzwspólnotowa dostawa towarów</td>
					<td class="wypelniane">
						<div class="opisrubryki">21.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_21"/>
						</div>
					</td>
					<td class="puste"/>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">8. Eksport towarów</td>
					<td class="wypelniane">
						<div class="opisrubryki">22.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_22"/>
						</div>
					</td>
					<td class="puste"/>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">9. Wewnątrzwspólnotowe nabycie towarów</td>
					<td class="wypelniane">
						<div class="opisrubryki">23.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_23"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="opisrubryki">24.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_24"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">10. Import towarów podlegający rozliczeniu zgodnie z art. 33a ustawy</td>
					<td class="wypelniane">
						<div class="opisrubryki">25.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_25"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="opisrubryki">26.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_26"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">11. Import usług z wyłączeniem usług nabywanych od podatników podatku od wartości dodanej, do których stosuje się art. 28b ustawy</td>
					<td class="wypelniane">
						<div class="opisrubryki">27.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_27"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="opisrubryki">28.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_28"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">12. Import usług nabywanych od podatników podatku od wartości dodanej, do których stosuje się art. 28b ustawy</td>
					<td class="wypelniane">
						<div class="opisrubryki">29.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_29"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="opisrubryki">30.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_30"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">13. Dostawa towarów oraz świadczenie usług, dla których podatnikiem jest nabywca zgodnie 
					z art. 17 ust. 1 pkt 7 lub 8 ustawy (wypełnia dostawca)</td>
					<td class="wypelniane">
						<div class="opisrubryki">31.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_31"/>
						</div>
					</td>
					<td class="puste"/>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">14. Dostawa towarów, dla których podatnikiem jest nabywca zgodnie z art. 17 ust. 1 pkt 5 ustawy (wypełnia nabywca)</td>
					<td class="wypelniane">
						<div class="opisrubryki">32.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_32"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="opisrubryki">33.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_33"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">15. Dostawa towarów oraz świadczenie usług, dla których podatnikiem jest nabywca zgodnie z art. 17 ust. 1 pkt 7 lub 8 ustawy (wypełnia nabywca)</td>
					<td class="wypelniane">
						<div class="opisrubryki">34.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_34"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="opisrubryki">35.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_35"/>
						</div>
					</td>
				</tr>
			</table>
			<table class="normalna">
				<tr>
					<td class="niewypelnianeopisy" style="width:75%">16. Kwota podatku należnego od towarów i usług objętych spisem z natury, o którym mowa w art. 14 ust. 5 ustawy</td>
					<td class="wypelniane">
						<div class="opisrubryki">36.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_36"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy" style="width:75%">17. Zwrot odliczonej lub zwróconej kwoty wydatkowanej na zakup kas rejestrujących, o którym mowa w art. 111 ust. 6 ustawy</td>
					<td class="wypelniane">
						<div class="opisrubryki">37.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_37"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy" style="width:75%">18. Kwota podatku należnego od wewnątrzwspólnotowego nabycia środków transportu, wykazanego w poz. 24, podlegająca wpłacie w terminie, o którym mowa w art. 103 ust. 3, w związku z ust. 4 ustawy</td>
					<td class="wypelniane">
						<div class="opisrubryki">38.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_38"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy" style="width:75%">19. Kwota podatku od wewnątrzwspólnotowego nabycia towarów, o których mowa w art. 103 ust. 5aa ustawy, podlegająca wpłacie w terminach, o których mowa w art. 103 ust. 5a i 5b ustawy</td>
					<td class="wypelniane">
						<div class="opisrubryki">39.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_39"/>
						</div>
					</td>
				</tr>
			</table>
			<table class="normalna">
				<tr>
					<td class="niewypelnianeopisy" style="width:50%">Razem</td>
					<td class="wypelniane" style="width:25%">
						<div class="opisrubryki">40.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_40"/>
						</div>
					</td>
					<td class="wypelniane" style="width:25%">
						<div class="opisrubryki">41.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_41"/>
						</div>
					</td>
				</tr>
			</table>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="RozliczeniePodatkuNaliczonego">
		<xsl:param name="sekcja"/>
		<xsl:for-each select="pf:PozycjeSzczegolowe">
			<h2 class="tytul-sekcja-blok">
				<xsl:value-of select="$sekcja"/> ROZLICZENIE PODATKU NALICZONEGO</h2>
			<h3 class="tytul-sekcja-blok">
				<xsl:value-of select="$sekcja"/>1. PRZENIESIENIA</h3>
			<table class="normalna">
				<td class="puste" style="width: 75%"/>
				<td class="niewypelniane" style="width:25%">Podatek do odliczenia w zł</td>
				<tr>
					<td class="niewypelnianeopisy">Kwota nadwyżki z poprzedniej deklaracji</td>
					<td class="wypelniane">
						<div class="opisrubryki">42.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_42"/>
						</div>
					</td>
				</tr>
			</table>
			<h3 class="tytul-sekcja-blok">
				<xsl:value-of select="$sekcja"/>2. NABYCIE TOWARÓW I USŁUG ORAZ PODATEK NALICZONY Z UWZGLĘDNIENIEM KOREKT</h3>
			<table class="normalna">
				<td class="puste" style="width: 50%"/>
				<td class="niewypelniane" style="width:25%">Wartość netto w zł</td>
				<td class="niewypelniane" style="width:25%">Podatek naliczony w zł</td>
				<tr>
					<td class="niewypelnianeopisy">Nabycie towarów i usług zaliczanych u podatnika do środków trwałych</td>
					<td class="wypelniane">
						<div class="opisrubryki">43.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_43"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="opisrubryki">44.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_44"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy">Nabycie towarów i usług pozostałych</td>
					<td class="wypelniane">
						<div class="opisrubryki">45.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_45"/>
						</div>
					</td>
					<td class="wypelniane">
						<div class="opisrubryki">46.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_46"/>
						</div>
					</td>
				</tr>
			</table>
			<h3 class="tytul-sekcja-blok">
				<xsl:value-of select="$sekcja"/>3. PODATEK NALICZONY - DO ODLICZENIA <span style="text-transform:lowercase">(w zł)</span>
			</h3>
			<table class="normalna">
				<td class="niewypelnianeopisy" style="width: 75%">Korekta podatku naliczonego od nabycia środków trwałych</td>
				<td class="wypelniane">
					<div class="opisrubryki">47.</div>
					<div class="kwota">
						<xsl:value-of select="pf:P_47"/>
					</div>
				</td>
				<tr>
					<td class="niewypelnianeopisy" style="width: 75%">Korekta podatku naliczonego od pozostałych nabyć</td>
					<td class="wypelniane">
						<div class="opisrubryki">48.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_48"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy" style="width: 75%">Korekta podatku naliczonego, o której mowa w art. 89b ust. 1 ustawy</td>
					<td class="wypelniane">
						<div class="opisrubryki">49.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_49"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy" style="width: 75%">Korekta podatku naliczonego, o której mowa w art. 89b ust. 4 ustawy</td>
					<td class="wypelniane">
						<div class="opisrubryki">50.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_50"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy" style="width: 75%">Razem kwota podatku naliczonego do odliczenia</td>
					<td class="wypelniane">
						<div class="opisrubryki">51.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_51"/>
						</div>
					</td>
				</tr>
			</table>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="ObliczenieZobowiązania">
		<xsl:param name="sekcja"/>
		<xsl:for-each select="pf:PozycjeSzczegolowe">
			<h2 class="tytul-sekcja-blok">
				<xsl:value-of select="$sekcja"/> OBLICZENIE WYSOKOŚCI ZOBOWIĄZANIA PODATKOWEGO LUB KWOTY ZWROTU <span style="text-transform:lowercase">(w zł)</span>
			</h2>
			<table class="normalna">
				<tr>
					<td class="niewypelnianeopisy" style="width: 75%">Kwota wydatkowana na zakup kas rejestrujących, do odliczenia w danym okresie rozliczeniowym</td>
					<td class="wypelniane" style="width:25%">
						<div class="opisrubryki">52.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_52"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy" style="width: 75%">Kwota podatku objęta zaniechaniem poboru</td>
					<td class="wypelniane" style="width:25%">
						<div class="opisrubryki">53.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_53"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy" style="width: 75%">Kwota podatku podlegającego wpłacie do urzędu skarbowego</td>
					<td class="wypelniane" style="width:25%">
						<div class="opisrubryki">54.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_54"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy" style="width: 75%">Kwota wydatkowana na zakup kas rejestrujących, przysługująca do zwrotu w danym okresie rozliczeniowym</td>
					<td class="wypelniane" style="width:25%">
						<div class="opisrubryki">55.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_55"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy" style="width: 75%">Nadwyżka podatku naliczonego nad należnym</td>
					<td class="wypelniane" style="width:25%">
						<div class="opisrubryki">56.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_56"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="niewypelnianeopisy" style="width: 75%">Kwota do zwrotu na rachunek wskazany przez podatnika</td>
					<td class="wypelniane" style="width:25%">
						<div class="opisrubryki">57.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_57"/>
						</div>
					</td>
				</tr>
			</table>
			<table class="normalna">
				<tr>
					<td class="niewypelnianeopisy" rowspan="2">   w tym kwota do zwrotu</td>
					<td class="wypelniane" style="width:25%">
						<div class="opisrubryki">58. na rachunek VAT</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_58"/>
						</div>
					</td>
					<td class="wypelniane" style="width:25%">
						<div class="opisrubryki">59. w terminie 25 dni (art. 87 ust. 6 ustawy)</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_59"/>
						</div>
					</td>
				</tr>
				<tr>
					<td class="wypelniane" style="width:25%">
						<div class="opisrubryki">60. w terminie 60 dni</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_60"/>
						</div>
					</td>
					<td class="wypelniane" style="width:25%">
						<div class="opisrubryki">61. w terminie 180 dni</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_61"/>
						</div>
					</td>
				</tr>
			</table>
			<table class="normalna">
				<tr>
					<td class="niewypelnianeopisy" style="width:75%">Kwota do przeniesienia na następny okres rozliczeniowy</td>
					<td class="wypelniane" style="width:25%">
						<div class="opisrubryki">62.</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_62"/>
						</div>
					</td>
				</tr>
			</table>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="InformacjeDodatkowe">
		<xsl:param name="sekcja"/>
		<xsl:for-each select="pf:PozycjeSzczegolowe">
			<h2 class="tytul-sekcja-blok">
				<xsl:value-of select="$sekcja"/> INFORMACJE DODATKOWE</h2>
			<table class="normalna">
				<tr>
					<td class="niewypelnianeopisy" style="width: 20%">Podatnik wykonywał w okresie rozliczeniowym czynności, o których mowa w (zaznaczyć właściwe kwadraty):</td>
					<xsl:if test="pf:P_63 =1">
						<td class="wypelniane">
							<div class="opisrubryki">63.</div>
							<input type="checkbox" checked="checked" disabled="disabled"/>art. 119 ustawy</td>
					</xsl:if>
					<xsl:if test="pf:P_64 =1">
						<td class="wypelniane">
							<div class="opisrubryki">64.</div>
							<input type="checkbox" checked="checked" disabled="disabled"/>art. 120 ust. 4 lub 5 ustawy</td>
					</xsl:if>
					<xsl:if test="pf:P_65 =1">
						<td class="wypelniane">
							<div class="opisrubryki">65.</div>
							<input type="checkbox" checked="checked" disabled="disabled"/>art. 122 ustawy</td>
					</xsl:if>
					<xsl:if test="pf:P_66 =1">
						<td class="wypelniane">
							<div class="opisrubryki">66.</div>
							<input type="checkbox" checked="checked" disabled="disabled"/>art. 136 ustawy</td>
					</xsl:if>
				</tr>
			</table>
			<table class="normalna">
				<tr>
					<td class="wypelniane">
						<div class="opisrubryki">67. Podatnik korzysta z obniżenia zobowiązania podatkowego, o którym mowa w art. 108d ustawy</div>
						<p style="text-align: center">
							<xsl:if test="pf:P_67 =1">
								<input type="checkbox" checked="checked" disabled="disabled"/>1. tak
						</xsl:if>
						</p>
					</td>
					<td class="wypelniane">
						<div class="opisrubryki">68. Podatnik wnioskuje o zwrot podatku na rachunek VAT (wykazany w poz. 58)</div>
						<p style="text-align: center">
							<xsl:if test="pf:P_68 =1">
								<input type="checkbox" checked="checked" disabled="disabled"/>1. tak
						</xsl:if>
						</p>
					</td>
				</tr>
			</table>
			<table class="normalna">
				<tr>
					<td class="wypelniane">
						<div class="opisrubryki">69. Podatnik wystawił w okresie rozliczeniowym fakturę, o której mowa w art. 106e ust. 1 pkt 18a ustawy</div>
						<p style="text-align: center">
							<xsl:if test="pf:P_69 =1">
								<input type="checkbox" checked="checked" disabled="disabled"/>1. tak
						</xsl:if>
						</p>
					</td>
				</tr>
			</table>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="InformacjaOZalaczniku">
		<xsl:param name="sekcja"/>
		<xsl:for-each select="pf:PozycjeSzczegolowe">
			<h2 class="tytul-sekcja-blok">
				<xsl:value-of select="$sekcja"/> INFORMACJA O ZAŁĄCZNIKU<br/>
				<font size="2pt">D<span style="text-transform:lowercase">o niniejszej deklaracji dołączono:</span>
				</font>
			</h2>
			<table class="normalna">
				<tr>
					<td class="wypelniane" style="width: 50%">
						<div class="opisrubryki">70. Zawiadomienie o skorygowaniu podstawy opodatkowania oraz kwoty podatku należnego (VAT-ZD)</div>
						<p style="text-align: center">
							<xsl:for-each select="pf:P_70">
								<xsl:call-template name="TakNie12"/>
							</xsl:for-each>
						</p>
					</td>
				</tr>
			</table>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="TelefoniData">
		<xsl:param name="sekcja"/>
		<xsl:for-each select="pf:PozycjeSzczegolowe">
			<h2 class="tytul-sekcja-blok">
				<xsl:value-of select="$sekcja"/> DANE KONTAKTOWE PODATNIKA LUB OSOBY REPREZENTUJĄCEJ PODATNIKA</h2>
			<table class="normalna">
				<tr>
					<td class="wypelniane" style="width: 33%">
						<div class="opisrubryki">73. Adres e-mail</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_73"/>
						</div>
					</td>
					<td class="wypelniane" style="width: 33%">
						<div class="opisrubryki">74. Telefon kontaktowy</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_74"/>
						</div>
					</td>
					<td class="wypelniane" style="width: 34%">
						<div class="opisrubryki">75. Data wypełnienia</div>
						<div class="kwota">
							<xsl:value-of select="pf:P_75"/>
						</div>
					</td>
				</tr>
			</table>
		</xsl:for-each>
	</xsl:template>
	<xsl:template name="PouczeniaKoncowe">
		<h3 align="justify">
			<font size="2pt">
				<sup>1)</sup> Zgodnie z art. 81 ustawy z dnia 29 sierpnia 1997 r. - Ordynacja podatkowa (Dz. U. z 2019 r. poz. 900, z późn. zm.).</font>
		</h3>
		<xsl:if test="pf:Pouczenia =1">
			<h2 class="tekst">Pouczenia</h2>
			<h3 align="justify">
				W przypadku niewpłacenia w obowiązującym terminie kwoty z poz. 54 lub wpłacenia jej w niepełnej wysokości, niniejsza deklaracja stanowi podstawę do wystawienia tytułu wykonawczego zgodnie z art. 3a § 1 pkt 1 ustawy z dnia 17 czerwca 1966 r. o postępowaniu egzekucyjnym w administracji (Dz. U. z 2019 r. poz. 1438, z późn. zm.).<br/>
				<br/>
Za podanie nieprawdy lub zatajenie prawdy i przez to narażenie podatku na uszczuplenie grozi odpowiedzialność przewidziana w Kodeksie karnym skarbowym.
			</h3>
		</xsl:if>
		<div class="lamstrone"/>
	</xsl:template>
	<xsl:template match="*[local-name()='OsobaFizyczna']">
		<xsl:param name="sekcja"/>
		<xsl:param name="wstaw-przed-ident"/>
		<h3 class="tytul-sekcja-blok">
			<xsl:if test="$sekcja">
				<xsl:value-of select="$sekcja"/> 
			</xsl:if>
			<xsl:text>Dane identyfikacyjne</xsl:text>
		</h3>
		<xsl:copy-of select="$wstaw-przed-ident"/>
		<table class="normalna">
			<tr>
				<td class="wypelniane">
					<div class="opisrubryki"> Identyfikator podatkowy NIP</div>
					<xsl:apply-templates select="*[local-name() = 'NIP']"/>
				</td>
			</tr>
		</table>
		<table class="normalna">
			<tr>
				<td class="wypelniane" style="width:50%">
					<div class="opisrubryki">Nazwisko</div>
					<xsl:apply-templates select="*[local-name()='Nazwisko']"/>
				</td>
				<td class="wypelniane" style="width:50%">
					<div class="opisrubryki">Pierwsze imię</div>
					<xsl:apply-templates select="*[local-name()='ImiePierwsze']"/>
				</td>
			</tr>
		</table>
	</xsl:template>
</xsl:stylesheet>