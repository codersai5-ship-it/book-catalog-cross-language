# Represents one book in the catalog.
# Ruby's dynamic typing allows attributes without declared types.
class Book
  attr_accessor :title, :author, :genre, :publication_year

  def initialize(title, author, genre, publication_year)
    @title = title
    @author = author
    @genre = genre
    @publication_year = publication_year
  end

  def to_s
    "#{title} by #{author} | Genre: #{genre} | Year: #{publication_year}"
  end
end
