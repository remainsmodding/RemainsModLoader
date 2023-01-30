# Remains Mod Loader

A mod loader and utility for Remains.

This is still in **_VERY_** early development! Contributions are very encouraged and a lot may change. All of the code is WIP.

## Installing

Do docs here yet! This still in **_VERY_** early development!

## Development

To get started, you will need the following DLLs:

- Libraries/Publicized/Assembly-CSharp.dll
- Libraries/Publicized/Assembly-CSharp-firstpass.dll
- Libraries/Default/Unity*.dll
- Libraries/Ak.Wwise.Api.WAAPI.dll
- Libraries/AK.Wwise.Unity.*.dll
- Libraries/Default/DOTween.dll
- Libraries/Default/GalaxyCSharp.dll

All of these can be obtained by using [Cpp2IL](https://github.com/SamboyCoding/Cpp2IL).

The publicized ones (Assembly-CSharp.dll, Assembly-CSharp-firstpass.dll) can also be obtained by running [AssemblyPublicizer](https://github.com/CabbageCrow/AssemblyPublicizer) after Cpp2IL.

After all of those are in the correct places, you can run `dotnet restore` and `dotnet build` to work on the project!
