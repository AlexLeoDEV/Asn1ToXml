# Asn1ToXml

This repository contains source code that will convert a private_key.pem file to private_key.xml
using fields structure from https://tls.mbed.org/kb/cryptography/asn1-key-structures-in-der-and-pem
Xml field structure will look like
```
<RSAKeyValue>
   <Modulus>…</Modulus>
   <Exponent>…</Exponent>
   <P>…</P>
   <Q>…</Q>
   <DP>…</DP>
   <DQ>…</DQ>
   <InverseQ>…</InverseQ>
   <D>…</D>
</RSAKeyValue>
```

Final xml file can be used to sign for example your links/cookies in .Net/Aws projects.

Example of use:

#### Using openssl generate private key with 2048 bit lenght
openssl genrsa -out private_key.pem 2048
#### Using openssl extract public key
openssl rsa -pubout -in private_key.pem -out public_key.pem

#### Using openssl and Asn1ToXml extract private key into xml file
openssl asn1parse -in private_key.pem | Asn1ToXml.exe > private_key.xml
