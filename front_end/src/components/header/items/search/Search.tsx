'use client';

import TextField from '@mui/material/TextField';
import Box from '@mui/material/Box';
import React from 'react';
import Suggest from './component/Suggest';

export interface suggestData {
    avatar: string;
    name: string;
    episode: string;
    href: string;
}
const Search = () => {
    const suggests: suggestData[] = [
        {
            href: 'day.html',
            avatar: 'https://cdn.animevietsub.art/data/poster/2024/02/02/animevsub-9sMhCo2GgN.jpg',
            name: 'Maou no Ore ga Dorei Elf wo Yome ni Shitanda ga, Dou Medereba Ii?',
            episode: '01',
        },
        {
            href: 'day.html',
            avatar: 'https://cdn.animevietsub.art/data/poster/2024/02/02/animevsub-9sMhCo2GgN.jpg',
            name: 'Maou no Ore ga Dorei Elf wo Yome ni Shitanda ga, Dou Medereba Ii?',
            episode: '01',
        },
        {
            href: 'day.html',
            avatar: 'https://cdn.animevietsub.art/data/poster/2024/02/02/animevsub-9sMhCo2GgN.jpg',
            name: 'Maou no Ore ga Dorei Elf wo Yome ni Shitanda ga, Dou Medereba Ii?',
            episode: '01',
        },
        {
            href: 'day.html',
            avatar: 'https://cdn.animevietsub.art/data/poster/2024/02/02/animevsub-9sMhCo2GgN.jpg',
            name: 'Maou no Ore ga Do?',
            episode: '01',
        },
        {
            href: 'day.html',
            avatar: 'https://cdn.animevietsub.art/data/poster/2024/02/02/animevsub-9sMhCo2GgN.jpg',
            name: 'Maou no Ore ga Dorei Elf wo Yome ni Shitanda ga, Dou Medereba Ii?',
            episode: '01',
        },
    ];

    const [openSuggest, setOpenSuggest] = React.useState(false);
    const [searchValue, setSearchValue] = React.useState('');

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const searchValue = e.target.value;
        if (!searchValue.startsWith(' ')) {
            setSearchValue(searchValue);
            setOpenSuggest(true);
        }
        if (searchValue.trim() == '') {
            setOpenSuggest(false);
        }
    };

    const handelFocus = () => {
        if (searchValue.trim() != '') {
            setOpenSuggest(true);
        }
    };

    const handelBlur = () => {
        setOpenSuggest(false);
    };

    return (
        <Box sx={{ flexGrow: 0, marginLeft: '10px', position: 'relative' }}>
            <TextField
                value={searchValue}
                onChange={handleChange}
                onFocus={handelFocus}
                onBlur={handelBlur}
                sx={{ width: '230px', padding: '2px 0' }}
                label="Search..."
                type="search"
                size="small"
            />
            <Box
                sx={{
                    position: 'absolute',
                    backgroundColor: '#263238',
                    boxShadow: 3,
                    display: `${openSuggest ? 'block' : 'none'}`,
                    zIndex: 1,
                    top: '110%',
                    width: '230px',
                }}
            >
                {suggests.map((suggest, index) => (
                    <Suggest key={index} suggestData={suggest} />
                ))}
            </Box>
        </Box>
    );
};

export default Search;
