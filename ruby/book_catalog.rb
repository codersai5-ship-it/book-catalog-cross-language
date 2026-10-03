require_relative 'book'

# In-memory Array stores Book objects. This mirrors the C# List<Book> implementation.
books = [
  Book.new('Clean Code', 'Robert C. Martin', 'Software Engineering', 2008),
  Book.new('The Pragmatic Programmer', 'Andrew Hunt and David Thomas', 'Software Engineering', 1999),
  Book.new('1984', 'George Orwell', 'Fiction', 1949)
]

def display_menu
  puts '1. Add Book'
  puts '2. Remove Book'
  puts '3. Display All Books'
  puts '4. Search by Title'
  puts '5. Search by Author'
  puts '6. Search by Genre'
  puts '7. Report by Author'
  puts '8. Report by Genre'
  puts '0. Exit'
end

def read_required(prompt)
  loop do
    print prompt
    value = gets&.strip.to_s
    return value unless value.empty?

    puts 'This field cannot be empty.'
  end
end

def read_year
  loop do
    print 'Publication year: '
    input = gets&.strip.to_s

    if input.match?(/^\d+$/)
      year = input.to_i
      return year if year.positive? && year <= Time.now.year
    end

    puts 'Enter a valid publication year.'
  end
end

def display_results(results, heading)
  puts "--- #{heading} ---"

  if results.empty?
    puts 'No books found.'
    return
  end

  # each block demonstrates Ruby's functional-style iteration.
  results.each { |book| puts book }
end

def add_book(books)
  title = read_required('Title: ')
  author = read_required('Author: ')
  genre = read_required('Genre: ')
  year = read_year

  books << Book.new(title, author, genre, year)
  puts 'Book added successfully.'
end

def remove_book(books)
  title = read_required('Enter the title to remove: ')

  # find_index uses a block to locate a matching book dynamically.
  index = books.find_index { |book| book.title.casecmp?(title) }

  if index.nil?
    puts 'No matching book was found.'
    return
  end

  removed = books.delete_at(index)
  puts "Removed: #{removed.title}"
end

def search_by_title(books)
  search = read_required('Enter title search text: ')
  results = books.select { |book| book.title.downcase.include?(search.downcase) }
  display_results(results, "Title Search: #{search}")
end

def search_by_author(books)
  search = read_required('Enter author search text: ')
  results = books.select { |book| book.author.downcase.include?(search.downcase) }
  display_results(results, "Author Search: #{search}")
end

def search_by_genre(books)
  search = read_required('Enter genre search text: ')
  results = books.select { |book| book.genre.downcase.include?(search.downcase) }
  display_results(results, "Genre Search: #{search}")
end

def report_by_author(books)
  puts '--- Books by Author ---'

  # group_by and blocks provide concise collection reporting in Ruby.
  books.group_by(&:author).sort.each do |author, author_books|
    puts "\n#{author} (#{author_books.length} book(s))"
    author_books.sort_by(&:title).each do |book|
      puts "  - #{book.title} (#{book.publication_year}) | #{book.genre}"
    end
  end
end

def report_by_genre(books)
  puts '--- Books by Genre ---'

  books.group_by(&:genre).sort.each do |genre, genre_books|
    puts "\n#{genre} (#{genre_books.length} book(s))"
    genre_books.sort_by(&:title).each do |book|
      puts "  - #{book.title} by #{book.author} (#{book.publication_year})"
    end
  end
end

puts '=== Book Cataloging System - Ruby ==='

loop do
  display_menu
  print 'Choose an option: '
  choice = gets&.strip.to_s
  puts

  case choice
  when '1' then add_book(books)
  when '2' then remove_book(books)
  when '3' then display_results(books.sort_by(&:title), 'All Books')
  when '4' then search_by_title(books)
  when '5' then search_by_author(books)
  when '6' then search_by_genre(books)
  when '7' then report_by_author(books)
  when '8' then report_by_genre(books)
  when '0'
    puts 'Goodbye!'
    break
  else
    puts 'Invalid option. Please choose 0-8.'
  end

  puts
end
