export interface Option {
    name: string,
    value: number
}

export interface Select {
    id: string;
    name: string;
    description: string;
    options: Option[];
}
