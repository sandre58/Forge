# Forge

**Kit d'ingénierie .NET personnelle** — baseline MSBuild / Cursor / GitHub + générateur de nouveaux repositories.

> **Git** = artefacts + how-to. **Notion (Forge)** = gouvernance, décisions, Playbook, roadmap.  
> Décisions structurantes → DB **Décisions** Notion uniquement (pas d’ADR dans ce repo).

## Quick start

```powershell
.\scripts\new-project.ps1 -Name MyProject -Type Library
.\scripts\new-project.ps1 -Name MyApp -Type App -CreateGitHub -OpenCursor
```

See [TEMPLATE.md](TEMPLATE.md) for all switches. Process / FAQ « que choisir » : Notion **Playbook**.

## Verify this kit

```powershell
.\scripts\Verify-Forge.ps1
```

## Layout

| Path | Role |
| ---- | ---- |
| `Directory.Build.*` + `build/` | MSBuild shared props, analyzers, CPM, packaging |
| `.cursor/rules/` | AI assistant rules |
| `.github/` | Kit CI (smoke) + Dependabot + PR/Issue templates |
| `templates/` | Project README/CI/repo.props used by `new-project.ps1` (not copied into children) |
| `samples/Smoke/` | Proves the baseline builds |
| `docs/how-it-works.md` | File map + generator flow (kit-only) |
| `docs/bootstrap-faq.md` | Technical FAQ (kit-only) |
| `scripts/new-project.ps1` | Bootstrap orchestrator |
| `scripts/Verify-Forge.ps1` | Kit smoke |
| `forge.manifest.json` | Generator metadata |

More detail: [docs/how-it-works.md](docs/how-it-works.md).

## Conventions

- **Default `IsPackable=false`** — libraries set `<IsPackable>true</IsPackable>` in the csproj (scaffold does this for `-Type Library`).
- **CPM** : versions in `Directory.Packages.props`
- **Commits** : Conventional Commits (`.gitmessage`) — `git config commit.template .gitmessage`
- **CI children** : Library → MyWorkflows + NuGet; App → build/test only
- **Versioning** : `GitVersion.yml` + MSBuild properties

## Local commit template (this repo)

```powershell
git config commit.template .gitmessage
```

## Hors scope (V1)

- Avalonia / XAML (→ MyAvalonia)
- Coverage gates avancés
- DevContainer / Renovate

## Licence

MIT — Stéphane ANDRE
