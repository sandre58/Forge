# How Forge works

Forge is a **kit + generator**, not an empty tree you copy blindly.

## Two surfaces

| Surface | Role |
| ------- | ---- |
| **This repo** | Executable artefacts + how-to (`README`, this file, `docs/bootstrap-faq.md`, scripts) |
| **Notion project Forge** | Governance, decisions, Playbook process, roadmap, tasks |

**Decisions never live in Git.** Use the Notion **Décisions** database on the Forge project (or on the child project page).

## Generator flow

```text
Forge kit  --new-project.ps1-->  child repo
                |
                +-- copy baseline (excl. kit-only)
                +-- tokenized README / CONTRIBUTING / repo.props
                +-- CI by -Type (Library | App)
                +-- dotnet new sln + src + tests
                +-- git init main + optional verify / gh / Cursor
```

Canonical metadata: [`forge.manifest.json`](../forge.manifest.json). Switches: [`TEMPLATE.md`](../TEMPLATE.md).

## Important paths

| Path | Role |
| ---- | ---- |
| `Directory.Build.props` / `.targets` | Defaults (packable=false, TFM, test adapter copy, analyzers import) |
| `Directory.Packages.props` | Central Package Management versions |
| `build/dependencies.props` | SourceLink + test package set for `*Tests` |
| `build/package.props` | NuGet metadata when packable |
| `build/repo.props` | `RepositoryUrl` (tokenized at bootstrap) |
| `templates/` | Kit-only sources for child README/CI/repo.props (**not** copied as a folder) |
| `samples/Smoke/` + `Forge.slnx` | Kit self-proof (excluded from children) |
| `.cursor/rules/` | AI conventions shipped into children |
| `.github/` | Kit smoke CI; children get Library or App workflow |
| `scripts/new-project.ps1` | Bootstrap |
| `scripts/Verify-Forge.ps1` | Kit smoke |

## Kit-only (never copied into children)

- `README.md`, `CONTRIBUTING.md`, `TEMPLATE.md`, `forge.manifest.json`
- `templates/`, `samples/`, `Forge.slnx`
- `docs/how-it-works.md`, `docs/bootstrap-faq.md` (this kit documentation)

## Child identity

Children get README/CONTRIBUTING from `templates/*.project.md` with tokens (`{{ProjectName}}`, `{{RepositoryUrl}}`, …). They should not describe the Forge kit.
