const API_BASE = "http://localhost:5093/api/books";

export interface Book {
  productCode: string;
  productName: string;
  productLine: string;
  buyPrice: number;
  quantityInStock: number;
  msrp: number;
}

export async function getBooks(): Promise<Book[]> {
  const res = await fetch(API_BASE);
  const data = (await res.json()) as Book[];
  return data;
}

export async function createBook(book: Book) {
  const res = await fetch(API_BASE, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(book),
  });

  if (!res.ok) {
    // eslint-disable-next-line @typescript-eslint/no-unsafe-assignment
    const data = await res.json();
    // eslint-disable-next-line @typescript-eslint/no-unsafe-member-access
    throw new Error(JSON.stringify(data.errors));
  }
}

export async function deleteBook(id: string) {
  const res = await fetch(`${API_BASE}/${id}`, {
    method: "DELETE",
  });

  if (!res.ok) {
    const text = await res.text();
    throw new Error(text);
  }
}

export async function getBook(id: string): Promise<Book> {
  const res = await fetch(`${API_BASE}/${id}`);
  const data = (await res.json()) as Book;
  return data;
}

export async function searchBooks(query: string): Promise<Book[]> {
  const res = await fetch(
    `${API_BASE}/search?query=${encodeURIComponent(query)}`,
  );
  const data = (await res.json()) as Book[];
  return data;
}
