<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xml" encoding="UTF-8" indent="yes" omit-xml-declaration="no" standalone="yes"/>
	<xsl:strip-space elements="*"/>
	<xsl:param name="country-name" />
	<xsl:template match="/">
		<xsl:for-each select="/countries/country[@name=$country-name]">
			<xsl:element name="country">
				<xsl:attribute name="name"><xsl:value-of select="$country-name"/></xsl:attribute>
				<xsl:copy-of select="@*|node()"/>
			</xsl:element>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>
