
export interface Product{
    id: string;
    productName: string;
    image: string;
    rating: number;
    categoryName: string;
    price: number;
}

export interface DialogData {
  animal: 'panda' | 'unicorn' | 'lion';
}