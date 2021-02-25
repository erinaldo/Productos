Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Web

Namespace EW.Encrypt

    Public Class HashPass

        ' The following constants may be changed without breaking existing hashes.
        Public Const SALT_BYTE_SIZE As Integer = 8

        Public Const HASH_BYTE_SIZE As Integer = 8

        Public Const PBKDF2_ITERATIONS As Integer = 1000

        Public Const SALT_INDEX As Integer = 0

        Public Const PBKDF2_INDEX As Integer = 1

        ''' <summary>
        ''' Creates a salted PBKDF2 hash of the password.
        ''' </summary>
        ''' <param name="password">The password to hash.</param>
        ''' <returns>The hash of the password.</returns>
        Public Shared Function CreateHash(ByVal password As String) As String
            ' Generate a random salt
            Dim csprng As RNGCryptoServiceProvider = New RNGCryptoServiceProvider
            Dim salt() As Byte = New Byte((SALT_BYTE_SIZE) - 1) {}
            csprng.GetBytes(salt)
            ' Hash the password and encode the parameters
            Dim hash() As Byte = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE)
            Return (Convert.ToBase64String(salt) & ":" & Convert.ToBase64String(hash))
        End Function

        ''' <summary>
        ''' Validates a password given a hash of the correct one.
        ''' </summary>
        ''' <param name="password">The password to check.</param>
        ''' <param name="correctHash">A hash of the correct password.</param>
        ''' <returns>True if the password is correct. False otherwise.</returns>
        Public Shared Function ValidatePassword(ByVal password As String, ByVal correctHash As String) As Boolean
            ' Extract the parameters from the hash
            Dim delimiter() As Char = New Char() {Microsoft.VisualBasic.ChrW(58)}
            Dim split() As String = correctHash.Split(delimiter)
            Dim result As Boolean = False

            If split.Length = 2 Then
                Dim iterations As Integer = PBKDF2_ITERATIONS
                Dim salt() As Byte = Convert.FromBase64String(split(SALT_INDEX))
                Dim hash() As Byte = Convert.FromBase64String(split(PBKDF2_INDEX))
                Dim testHash() As Byte = PBKDF2(password, salt, iterations, hash.Length)
                result = SlowEquals(hash, testHash)
            Else
                If password = ModPOS.DecryptText(correctHash, "AlpeGroup") Then
                    result = True
                Else
                    result = False
                End If
            End If

            Return result

        End Function

        ''' <summary>
        ''' Compares two byte arrays in length-constant time. This comparison
        ''' method is used so that password hashes cannot be extracted from
        ''' on-line systems using a timing attack and then attacked off-line.
        ''' </summary>
        ''' <param name="a">The first byte array.</param>
        ''' <param name="b">The second byte array.</param>
        ''' <returns>True if both byte arrays are equal. False otherwise.</returns>
        Private Shared Function SlowEquals(ByVal a() As Byte, ByVal b() As Byte) As Boolean
            Dim diff As UInteger = (CType(a.Length, UInteger) Xor CType(b.Length, UInteger))
            'The operator should be an XOR ^ instead of an OR, but not available in CodeDOM
            Dim i As Integer = 0
            Do While ((i < a.Length) AndAlso (i < b.Length))
                diff = (diff Or (CType(a(i), UInteger) Xor CType(b(i), UInteger)))
                i = (i + 1)
            Loop

            'The operator should be an XOR ^ instead of an OR, but not available in CodeDOM
            Return (diff = 0)
        End Function

        ''' <summary>
        ''' Computes the PBKDF2-SHA1 hash of a password.
        ''' </summary>
        ''' <param name="password">The password to hash.</param>
        ''' <param name="salt">The salt.</param>
        ''' <param name="iterations">The PBKDF2 iteration count.</param>
        ''' <param name="outputBytes">The length of the hash to generate, in bytes.</param>
        ''' <returns>A hash of the password.</returns>
        Private Shared Function PBKDF2(ByVal password As String, ByVal salt() As Byte, ByVal iterations As Integer, ByVal outputBytes As Integer) As Byte()
            Dim pbkdf As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(password, salt)
            pbkdf.IterationCount = iterations
            Return pbkdf.GetBytes(outputBytes)
        End Function
    End Class
End Namespace
