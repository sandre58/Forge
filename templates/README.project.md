<div align="center">

# {{ProjectName}}

{{ProjectDescription}}

[![License](https://img.shields.io/github/license/{{Org}}/{{ProjectName}}?style=for-the-badge)]({{RepositoryUrl}}/blob/main/LICENSE)
[![GitHub issues](https://img.shields.io/github/issues/{{Org}}/{{ProjectName}}?style=for-the-badge)]({{RepositoryUrl}}/issues)
[![Last commit](https://img.shields.io/github/last-commit/{{Org}}/{{ProjectName}}/main?style=for-the-badge)]({{RepositoryUrl}}/commits/main/)
[![Repo size](https://img.shields.io/github/repo-size/{{Org}}/{{ProjectName}}?style=for-the-badge)]({{RepositoryUrl}})

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge)](https://dotnet.microsoft.com/download/dotnet/10.0)
[![Language](https://img.shields.io/github/languages/top/{{Org}}/{{ProjectName}}?style=for-the-badge)]({{RepositoryUrl}}/search?l=c%23)

[![CI](https://github.com/{{Org}}/{{ProjectName}}/actions/workflows/ci.yml/badge.svg?branch=main)]({{RepositoryUrl}}/actions/workflows/ci.yml)

[![Semantic Versioning](https://img.shields.io/badge/SemVer-2.0.0-3C1E70?style=for-the-badge)](https://semver.org/)
[![Conventional Commits](https://img.shields.io/badge/Conventional%20Commits-1.0.0-FE5196?style=for-the-badge)](https://www.conventionalcommits.org/)

[Contributing](CONTRIBUTING.md) · [Security](SECURITY.md) · [Issues]({{RepositoryUrl}}/issues)

</div>

---

## Overview

{{ProjectDescription}}

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (see `global.json`)
- Git

## Getting started

```bash
dotnet restore
dotnet build
dotnet test
```

## Repository layout

| Path | Purpose |
| :--- | :------ |
| `src/` | Product / library projects |
| `tests/` | Test projects (`*Tests`) |
| `build/` | Shared MSBuild props |
| `.github/` | CI, Dependabot, issue/PR templates |

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md). Use [Conventional Commits](https://www.conventionalcommits.org/).

## License

[MIT](LICENSE) © {{Year}} — see repository license file.

---

Bootstrapped from [Forge](https://github.com/sandre58/Forge) ({{Year}}).
