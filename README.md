# BO-TowerDefence

## In deze repository staat mijn beroeps opdracht Tower Defence van de eerste periode uit het tweede jaar op het mediacollege.

## Het spel.

### In dit spel is het de bedoeling dat je voorkomt dat de vijanden bij jouw basis komen.

### de mechanics: 
### 1. toren plaatsen:
#### Bij het toren plaatsen heb ik veel problemen gehad met de layermasks correct aangeven, dit heb ik uiteindelijk opgelost door de layermask te debuggen en goed neer te zetten.
### 2. Toren schieten:
#### Ik heb het schieten gemaakt door een raycast te schieten uit de toren die op de vijand focust en vervolgens uit het script van de vijand hp pakt en damage er bij doet.

### 3. vijanden AI:
#### Ik heb de vijanden geprogrammeerd om een rechte lijn te volgen en dan wanneer hij een checkpoint raakt de rotatie van het checkpoint over te nemen.

### 4. UI:
#### De UI heb ik gecreëerd met knoppen en ik heb er heel lang over gedaan om het allemaal goed te plaatsen.



```mermaid
flowchart TD
start((start))
start ---> vraag1{player drukt op knop?}
vraag1 ---> antwoord1[ja] & antwoord2[nee]
antwoord2 --> i[spawn niet de toren]
antwoord1 --> shop[haal geld er af en spawn toren]