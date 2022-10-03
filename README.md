# BO-TowerDefence

## hier zal ik mijn tower defence game neerzetten


```mermaid
flowchart TD
start((start))
start ---> vraag1{player drukt op knop?}
vraag1 ---> antwoord1[ja] & antwoord2[nee]
antwoord2 --> i[spawn niet de toren]
antwoord1 --> shop[haal geld er af en spawn toren]