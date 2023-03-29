# PowerRename for Unity

PowerRename <small> for Unity </small> is Unity editor extension for renaming GameObjects in hierarchy.  
You can flexible renaming by specifying the renaming convention in pipe format.

## Rename Conventions

### Append Prefix

Append specified string as prefix.

| Value | Before       | After           |
| ----- | ------------ | --------------- |
| `go_` | `GameObject` | `go_GameObject` |

### Append Sequential Number to Prefix

Append sequential number with digit as prefix.

| Digits | Start Index | Before       | After           |
| ------ | ----------- | ------------ | --------------- |
| `3`    | `1`         | `GameObject` | `001GameObject` |

### Append Sequential Number to Suffix

Append sequential number with digit as suffix.

| Digits | Start Index | Before       | After           |
| ------ | ----------- | ------------ | --------------- |
| `3`    | `1`         | `GameObject` | `GameObject001` |

### Append Suffix

Append specified string as suffix.

| Value | Before       | After           |
| ----- | ------------ | --------------- |
| `_go` | `GameObject` | `GameObject_go` |

### Remove leading space

Remove leading spaces.

| Before        | After        |
| ------------- | ------------ |
| ` GameObject` | `GameObject` |

### Remove Prefix

Remove specified characters from prefix.

| Length | Before          | After        |
| ------ | --------------- | ------------ |
| `3`    | `go_GameObject` | `GameObject` |

### Remove Suffix

Remove specified characters from suffix.

| Length | Before          | After        |
| ------ | --------------- | ------------ |
| `3`    | `GameObject_go` | `GameObject` |

### Remove trailing space

Remove trailing spaces.

| Before        | After        |
| ------------- | ------------ |
| `GameObject ` | `GameObject` |

### Replace by Regular Expression

Replace matched strings.

| Pattern   | To        | Before           | After         |
| --------- | --------- | ---------------- | ------------- |
| `\(\d+\)` | `(empty)` | `GameObject (1)` | `GameObject ` |

### Replace by String

Replace matched strings.

| From   | To        | Before           | After        |
| ------ | --------- | ---------------- | ------------ |
| ` (1)` | `(empty)` | `GameObject (1)` | `GameObject` |

### To kebab-case

Convert to kebab-case

| Before       | After         |
| ------------ | ------------- |
| `GameObject` | `game-object` |

### To lowerCamelCase

Convert to lowerCamelCase

| Before       | After        |
| ------------ | ------------ |
| `GameObject` | `gameObject` |

### To lowercase

Convert to lowercase

| Before       | After        |
| ------------ | ------------ |
| `GameObject` | `gameobject` |

### To snake_case

Convert to snake_case

| Before       | After         |
| ------------ | ------------- |
| `GameObject` | `game_object` |

### To Train-Case

Convert to Train-Case

| Before       | After         |
| ------------ | ------------- |
| `GameObject` | `Game-Object` |

### To UpperCamelCase

Convert to lowercase

| Before       | After        |
| ------------ | ------------ |
| `gameObject` | `GameObject` |

### To UPPERCASE

Convert to UPPERCASE

| Before       | After        |
| ------------ | ------------ |
| `GameObject` | `GAMEOBJECT` |

### To UPPER_SNAKE_CASE

Convert to UPPER_SNAKE_CASE

| Before       | After         |
| ------------ | ------------- |
| `GameObject` | `GAME_OBJECT` |

## Combination Examples

### I want to 3-digit numbers to suffix, starts with 0, and remove existing suffix

1. Replace by Regular Expression (Pattern: `\(\d+\)`, To: `(empty)`)
2. Remove trailing space
3. Append Suffix (Value: `_` )
4. Append Sequential Number to Suffix (Digits: `3`, Start Index: `0`)

| Before           | After            |
| ---------------- | ---------------- |
| `GameObject`     | `GameObject_000` |
| `GameObject (1)` | `GameObject_001` |
| `GameObject (2)` | `GameObject_002` |

## Extend

If you want to add other rename conventions, create C# script into `PowerRename` directory and implement `IRenameConvention` interface.

## I want to link animation files as well

Please use [Animation Auto Assignment](https://github.com/natsuneko-laboratory/animation-auto-assignment)

## License

MIT by [@6jz](https://twitter.com/6jz)
