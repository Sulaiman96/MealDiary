export interface Meal {
    name: string,
    location: string,
    price: number,
    review: string,
    photoUrl: string,
    createdOn: string,
    lastModified: string,
    rating: number,
    cuisine: string,
    collectionName: string,
    ingredients: Ingredients[],
    photos: Photos[]
}

export interface Photos {
    url: string,
    isMain: boolean
}

export interface Ingredients {
    string: name
}


