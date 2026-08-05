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
                +-- copy baseline (excl. kit-only from forge.manifest.json)
                +-- tokenized README / CONTRIBUTING / LICENSE / repo.props / .slnx
                +-- CI by -Type (Library | App)
                +-- dotnet new src + tests (slim csproj; Directory.Build supplies TFM)
                +-- git init main + optional verify / gh / Cursor
```

Canonical metadata: [`forge.manifest.json`](../forge.manifest.json). Switches: [`TEMPLATE.md`](../TEMPLATE.md).

`new-project.ps1` **reads** `excludeFromCopy`, `ci`, and `projectTemplates` from the manifest (single source of truth).

## Important paths

| Path | Role |
| ---- | ---- |
| `Directory.Build.props` / `.targets` | Defaults (packable=false, TFM, test adapter copy, analyzers import) |
| `Directory.Packages.props` | Central Package Management versions |
| `build/dependencies.props` | SourceLink + test package set for `*Tests` |
| `build/package.props` | NuGet metadata when packable (`RepositoryUrl` from `repo.props`) |
| `build/repo.props` | `RepositoryUrl` (tokenized at bootstrap) |
| `templates/` | Kit-only sources for child README/CI/LICENSE/repo.props/`.slnx` (**not** copied as a folder) |
| `samples/Smoke/` + `Forge.slnx` | Kit self-proof (excluded from children) |
| `.cursor/rules/` | AI conventions shipped into children |
| `.github/` | Kit smoke CI; children get Library or App workflow |
| `scripts/new-project.ps1` | Bootstrap (**kit-only** — not copied into children) |
| `scripts/Verify-Forge.ps1` | Kit smoke (**kit-only**) |

## Kit-only (never copied into children)

See `forge.manifest.json` `excludeFromCopy`. Notably:

- `README.md`, `CONTRIBUTING.md`, `TEMPLATE.md`, `LICENSE`, `forge.manifest.json`
- `templates/`, `samples/`, `scripts/`, `Forge.slnx`
- `docs/` (this kit documentation)

## Child identity

Children get README/CONTRIBUTING/LICENSE/`.slnx` from `templates/` with tokens (`{{ProjectName}}`, `{{RepositoryUrl}}`, `{{Org}}`, `{{Year}}`, …). The generated solution uses folders `/src/`, `/tests/`, `/build/`, `/docs/`, `/github/`, `/cursor/rules/`. Public GitHub docs are **English**. They should not describe the Forge kit beyond a brief bootstrap credit.
