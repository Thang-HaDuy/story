'use client';

import Box from '@mui/material/Box';
import TitleSidebar from '@/components/sidebar/item/TitleSidebar';
import Button from '@mui/material/Button';
import ItemAnimeHot from './ItemAnimeHot';
import { useState } from 'react';
import { IInforItem } from '@/components/ui/InforList';

export interface IItemAnime {
    name: string;
    className: string;
    img: string;
    info: IInforItem;
}

const AnimeHot = () => {
    const itemAnime: IItemAnime[] = [
        {
            name: 'Anime1',
            className: 'Animehaha1',
            img: '/name1.jpg',
            info: {
                rating: 4.3,
                date: '2024-06-16 12:42:44.779',
                quality: 'FHD',
                period: '6/7',
            },
        },
        {
            name: 'Anime1',
            className: 'Animehaha1',
            img: '/name1.jpg',
            info: {
                rating: 4.3,
                date: '2024-06-16 12:42:44.779',
                quality: 'FHD',
                period: '6/7',
            },
        },
        {
            name: 'Anime1',
            className: 'Animehaha1',
            img: '/name1.jpg',
            info: {
                rating: 4.3,
                date: '2024-06-16 12:42:44.779',
                quality: 'FHD',
                period: '6/7',
            },
        },
        {
            name: 'Anime1',
            className: 'Animehaha1',
            img: '/name1.jpg',
            info: {
                rating: 4.3,
                date: '2024-06-16 12:42:44.779',
                quality: 'FHD',
                period: '6/7',
            },
        },
        {
            name: 'Anime1',
            className: 'Animehaha1',
            img: '/name1.jpg',
            info: {
                rating: 4.3,
                date: '2024-06-16 12:42:44.779',
                quality: 'FHD',
                period: '6/7',
            },
        },
    ];
    const buttonLabels = ['TV/Series', 'Movie/OVA'];
    const [activeButton, setActiveButton] = useState<string | null>('TV/Series');

    const handleButtonClick = (buttonLabel: string) => {
        setActiveButton(buttonLabel);
    };
    return (
        <Box sx={{ padding: '10px', marginBottom: '20px', backgroundColor: '#181d1f', borderRadius: '3px' }}>
            <TitleSidebar content={'HOT TUẦN'}>
                <Box component="span" sx={{ marginLeft: '20px', display: 'flex' }}>
                    {buttonLabels.map((label, index) => (
                        <Button
                            key={index}
                            onClick={() => handleButtonClick(label)}
                            sx={{
                                paddingX: '15px',
                                lineHeight: '40px',
                                paddingY: '0',
                                fontSize: '14px',
                                fontWeight: '400',
                                color: activeButton != label ? 'white' : '#f44336',
                                '&:hover': { backgroundColor: 'transparent' },
                            }}
                        >
                            {label}
                        </Button>
                    ))}
                </Box>
            </TitleSidebar>
            <Box>
                {itemAnime.map((item, index) => {
                    return <ItemAnimeHot key={index} item={item} index={index} />;
                })}
            </Box>
        </Box>
    );
};

export default AnimeHot;
