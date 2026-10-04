# Book Cataloging System – Cross-Language Project

**Course:** MSCS 632 – Advanced Programming Languages  
**University:** University of the Cumberlands  
**Project Option:** 4 – Book Cataloging System  
**Languages:** C# and Ruby

## Team Members

- Sai Jeswanth Reddy Pochana
- Sheethal Yellisetty

## Project Overview

This project implements the same standalone Book Cataloging System in **C#** and **Ruby**. Both versions provide equivalent functionality so that the implementations can be compared based on language design, syntax, type systems, collections, object-oriented programming, readability, writability, and language-specific collection-processing features.

The application is console based so the project can focus on programming-language concepts rather than user-interface frameworks.

## Core Functionality

Both implementations support the following operations:

- Add a book
- Remove a book by title
- Display all books
- Search by title
- Search by author
- Search by genre
- Generate a report grouped by author
- Generate a report grouped by genre
- Validate required text fields
- Validate publication year input
- Display clear messages when no matching books are found
- Reject invalid menu selections

Each book contains four fields:

- Title
- Author
- Genre
- Publication year

Three sample books are loaded when each application starts so the features can be demonstrated immediately. Catalog changes are stored **in memory** for the duration of the program and reset when the application is restarted.

## C# Implementation

The C# implementation demonstrates features associated with a statically typed, object-oriented language:

- `Book` class with strongly typed properties
- `List<Book>` generic collection for catalog storage
- LINQ `Where` for searching/filtering
- LINQ `FirstOrDefault` for locating a book to remove
- LINQ `GroupBy` for author and genre reports
- LINQ `OrderBy` for deterministic output ordering
- Lambda expressions for collection queries
- `IEnumerable<Book>` for reusable result handling
- `int.TryParse` for safe publication-year validation
- `StringComparison.OrdinalIgnoreCase` for case-insensitive matching

### C# Requirements

- .NET 10 SDK

### Build and Run C#

From the repository root:

```bash
dotnet restore csharp/BookCatalog/BookCatalog.csproj
dotnet build csharp/BookCatalog/BookCatalog.csproj
dotnet run --project csharp/BookCatalog/BookCatalog.csproj
```

## Ruby Implementation

The Ruby implementation provides the same behavior while demonstrating Ruby's dynamic and block-oriented programming style:

- `Book` class without declared attribute types
- `Array` for catalog storage
- `attr_accessor` for book properties
- `select` blocks for searching/filtering
- `find_index` for locating a book to remove
- `group_by` for author and genre reports
- `sort_by` for deterministic output ordering
- `each` blocks for iteration
- Symbol-to-proc syntax such as `&:title`
- Runtime publication-year validation

### Ruby Requirements

- Ruby 3.x

### Run Ruby

From the repository root:

```bash
ruby ruby/book_catalog.rb
```

## Repository Structure

```text
book-catalog-cross-language/
├── .gitignore
├── README.md
├── csharp/
│   └── BookCatalog/
│       ├── Book.cs
│       ├── BookCatalog.csproj
│       └── Program.cs
├── ruby/
│   ├── book.rb
│   └── book_catalog.rb
└── docs/
```

## Testing and Debugging

Both applications were manually tested using the same functional workflow to verify equivalent behavior. Testing covered:

1. Displaying the initial catalog
2. Adding a new book
3. Searching by title
4. Searching by author
5. Searching by genre
6. Generating the author report
7. Generating the genre report
8. Searching for a nonexistent book to verify the no-results case
9. Removing an existing book
10. Displaying the catalog again to confirm removal
11. Exiting the application normally

Input validation was also exercised during development. The C# project was updated to target .NET 10 to match the available development environment. Generated .NET `bin` and `obj` directories are excluded through `.gitignore`.

## Demo Instructions

The same test sequence can be used in both implementations to demonstrate feature parity.

### C# Demo

Run from the repository root:

```bash
dotnet run --project csharp/BookCatalog/BookCatalog.csproj
```

Enter the following values in order as the application prompts for input:

```text
3

1
The Hobbit
J.R.R. Tolkien
Fantasy
1937

4
Hobbit

5
Tolkien

6
Fantasy

7

8

2
The Hobbit

4
Hobbit

0
```

This sequence displays the initial catalog, adds *The Hobbit*, searches by title, author, and genre, generates both reports, removes the book, confirms the removal with a no-results search, and exits.

### Ruby Demo

Run from the repository root:

```bash
ruby ruby/book_catalog.rb
```

Use the same test sequence:

```text
3

1
The Hobbit
J.R.R. Tolkien
Fantasy
1937

4
Hobbit

5
Tolkien

6
Fantasy

7

8

2
The Hobbit

4
Hobbit

0
```

Both implementations should provide equivalent results for the same operations.

## C# and Ruby Comparison Highlights

| Area | C# | Ruby |
|---|---|---|
| Type system | Static typing | Dynamic typing |
| Catalog collection | `List<Book>` | `Array` |
| Search/filter | LINQ `Where` | `select` block |
| Find item | `FirstOrDefault` | `find_index` |
| Grouping | LINQ `GroupBy` | `group_by` |
| Sorting | LINQ `OrderBy` | `sort_by` |
| Iteration | `foreach` | `each` blocks |
| Input conversion | `int.TryParse` | Runtime string/integer validation |
| General style | Explicit and strongly typed | Concise and dynamically typed |

## Current Status

The core C# and Ruby implementations are complete, operational, commented, and functionally tested. Both applications implement the same required features while using language-specific constructs appropriate to C# and Ruby.
