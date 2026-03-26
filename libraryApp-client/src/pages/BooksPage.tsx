import { useState } from "react";
import {
  getBooks,
  createBook,
  deleteBook,
  type Book,
  searchBooks,
} from "../api/booksApi";

import styles from "./booksPage.module.css"

const initBooks = await getBooks();

export default function BooksPage() {
  const [books, setBooks] = useState<Book[]>(initBooks);
  const [title, setTitle] = useState("");
  const [search, setSearch] = useState("");

  async function loadBooks() {
    try {
      if (search.trim() === "") {
        const data = await getBooks();
        setBooks(data);
      } else {
        const data = await searchBooks(search);
        setBooks(data);
      }
    } catch (err) {
      alert(err);
    }
  }

  async function handleAdd() {
    const newBook: Book = {
      productCode: "B" + Math.floor(Math.random() * 10000),
      productName: title,
      productLine: "Classic Cars",
      buyPrice: 10,
      quantityInStock: 100,
      msrp: 20,
    };

    try {
      await createBook(newBook);
      setTitle("");
      void loadBooks();
    } catch (err) {
      alert(err);
    }
  }

  async function handleDelete(id: string) {
    try {
      await deleteBook(id);
      void loadBooks();
    } catch (err) {
      alert(err);
    }
  }

  return (
    <div style={{padding: "2rem"}}>
      <h1>Books</h1>

      <input
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        placeholder="Book title"
      />
      <button onClick={() => void handleAdd()}>Add</button>
      <input
        value={search}
        onChange={(e) => setSearch(e.target.value)}
        placeholder="Search books..."
      />
      <button key="searchButton" onClick={() => void loadBooks()}>
        Search
      </button>
      <ul  className={styles.bookList}>
        {books.map((b) => (
          <li key={b.productCode} className={styles.book}>
            {b.productName} (${b.buyPrice})
            <button onClick={() => void handleDelete(b.productCode)}>
              Delete
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}
