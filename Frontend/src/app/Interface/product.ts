export interface Product {
  productId: number;
  name: string;
  categoryId: number;
  categoryName?: string;
  stock: number;
  price: string;
  isActive: number;
}
