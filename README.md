# AOP

## Notes

This AOP is implemented by Unity container.
It include the below dependencies from Nuget.

 | Dependency         | version |
 | ------------------ | ------- |
 | Unity              | v5.5.6  |
 | Unity.Interception | v5.1.0  |
 | Unity.Abstractions | v3.0.0  |

The latest version of Unity is **v5.8.11** and Unity.Interception is **v5.5.5** from today.

When I try use the latest vesion it failed and cannot create dynamic instance of the specified interface by means of interception filter.
I haven't any idea about it until now. It maybe a bug in Unity or it will be fixed in the future version.