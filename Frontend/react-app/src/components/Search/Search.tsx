import React, { ChangeEvent, SyntheticEvent } from 'react'

interface Props {
    onClickEvent: (e: SyntheticEvent) => void;
    search: string | undefined;
    handleChange: (e: ChangeEvent<HTMLInputElement>) => void;
}

const Search: React.FC<Props> = ({ search, onClickEvent, handleChange }: Props): JSX.Element => {
    return (
        <div>
            <input value={search} onChange={(e) => handleChange(e)} type="text" />
            <button onClick={(e) => onClickEvent(e)} />
        </div>
    )
}

export default Search