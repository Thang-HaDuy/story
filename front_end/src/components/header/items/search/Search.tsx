'use client';

import TextField from '@mui/material/TextField';
import Box from '@mui/material/Box';
import React from 'react';
import Suggest, { ISuggest } from './component/Suggest';
import IconButton from '@mui/material/IconButton';
import InputAdornment from '@mui/material/InputAdornment';
import SearchIcon from '@mui/icons-material/Search';
import useDebounce from './component/useDebounce';

const Search = () => {
    const [openSuggest, setOpenSuggest] = React.useState(false);
    const [searchValue, setSearchValue] = React.useState('');
    const [searchResult, setSearchResult] = React.useState<ISuggest[]>([]);

    const debouncedValue = useDebounce(searchValue, 500);

    React.useEffect(() => {
        if (!debouncedValue) {
            setSearchResult([]);
            return;
        }

        const fetchApi = async () => {
            try {
                const response = await fetch(
                    `${process.env.NEXT_PUBLIC_BASE_API}api/MovieControllerApi/search?query=${debouncedValue}`,
                );
                if (response.status === 200) {
                    const result: ISuggest[] = await response.json();
                    setSearchResult(result);
                }
                if (response.status === 204) {
                    setSearchResult([]);
                }
            } catch (error) {
                console.log(error);
            }
        };

        fetchApi();
    }, [debouncedValue]);
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

    const handleOnSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
    };

    return (
        <Box
            sx={{
                flexGrow: { xs: 1, md: 0 },
                marginLeft: '10px',
                position: 'relative',
                display: 'flex',
                justifyContent: 'flex-end',
            }}
        >
            <Box component="form" onSubmit={handleOnSubmit} sx={{ display: 'flex', alignItems: 'center' }}>
                <TextField
                    value={searchValue}
                    onChange={handleChange}
                    onFocus={handelFocus}
                    onBlur={handelBlur}
                    sx={{ width: '230px', padding: '2px 0' }}
                    label="Search..."
                    type="search"
                    size="small"
                    InputProps={{
                        startAdornment: (
                            <InputAdornment position="start">
                                <IconButton sx={{ p: 0 }} type="submit">
                                    <SearchIcon
                                        sx={{
                                            color: 'rgba(255, 255, 255, 0.7)',
                                            cursor: 'pointer',
                                            '&:hover': { color: '#fff' },
                                        }}
                                    />
                                </IconButton>
                            </InputAdornment>
                        ),
                    }}
                />
            </Box>
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
                {searchResult.map((suggest, index) => (
                    <Suggest key={index} suggestData={suggest} />
                ))}
            </Box>
        </Box>
    );
};

export default Search;
