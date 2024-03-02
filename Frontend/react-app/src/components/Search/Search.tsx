import { Input } from '@material-tailwind/react';
import React, { ChangeEvent, SyntheticEvent } from 'react'

interface Props {
    onSearchSubmit: (e: SyntheticEvent) => void;
    search: string | undefined;
    handleSearchChange: (e: ChangeEvent<HTMLInputElement>) => void;
}

const Search: React.FC<Props> = ({ search, onSearchSubmit, handleSearchChange }: Props): JSX.Element => {
    return (
        <>
            <form onSubmit={onSearchSubmit}>
                <Input
                    type="search"
                    placeholder="Search"
                    crossOrigin={''}
                    value={search}
                    onChange={handleSearchChange}
                    containerProps={{
                        className: "min-w-[288px]",
                    }}
                    className=" !border-t-blue-gray-800 pl-9 placeholder:text-blue-gray-800 focus:!border-blue-gray-800"
                    labelProps={{
                        className: "before:content-none after:content-none",
                    }}
                />
            </form>
        </>
    )
}

export default Search