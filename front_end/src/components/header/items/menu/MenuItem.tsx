import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import Link from 'next/link';
import MenuDropDown from './MenuDropDown';
import { Item } from './ItemDropdown';

export const topAnime: Item[] = [
    { href: 'day.html', text: 'Theo Ngày' },
    { href: 'seasion.html', text: 'Theo Mùa' },
    { href: 'year.html', text: 'Theo Năm' },
    { href: 'month.html', text: 'Theo Tháng' },
    { href: 'voied.html', text: 'Yêu Thích' },
];
export const theLoai: Item[] = [
    { href: 'day.html', text: 'Action' },
    { href: 'seasion.html', text: 'Adventure' },
    { href: 'year.html', text: 'Cartoon' },
    { href: 'month.html', text: 'Comedy' },
    { href: 'voied.html', text: 'Dementia' },
    { href: 'voied.html', text: 'Demons' },
    { href: 'voied.html', text: 'Drama' },
    { href: 'voied.html', text: 'Ecchi' },
    { href: 'voied.html', text: 'Fantasy' },
    { href: 'voied.html', text: 'Game' },
    { href: 'voied.html', text: 'Harem' },
    { href: 'voied.html', text: 'Historical' },
    { href: 'voied.html', text: 'Horror' },
    { href: 'voied.html', text: 'Josei' },
    { href: 'voied.html', text: 'Kids' },
    { href: 'voied.html', text: 'Magic' },
    { href: 'voied.html', text: 'Mecha' },
    { href: 'voied.html', text: 'Military' },
    { href: 'voied.html', text: 'Music' },
    { href: 'voied.html', text: 'Mystery' },
    { href: 'voied.html', text: 'Parody' },
    { href: 'voied.html', text: 'Police' },
    { href: 'voied.html', text: 'Psychological' },
    { href: 'voied.html', text: 'Romance' },
    { href: 'voied.html', text: 'Samurai' },
    { href: 'voied.html', text: 'Shounen' },
];
export const seasion: Item[] = [
    { href: 'day.html', text: 'Mùa Đông 2024' },
    { href: 'seasion.html', text: 'Mùa Xuân 2024' },
    { href: 'year.html', text: 'Mùa Hạ 2024' },
    { href: 'month.html', text: 'Mùa Thu 2024' },
    { href: 'voied.html', text: 'Mùa Đông 2023' },
    { href: 'voied.html', text: 'Mùa Xuân 2023' },
    { href: 'voied.html', text: 'Mùa Hạ 2023' },
    { href: 'voied.html', text: 'Mùa Thu 2023' },
    { href: 'voied.html', text: 'Mùa Thu 2022' },
    { href: 'voied.html', text: 'Mùa Đông 2022' },
    { href: 'voied.html', text: 'Mùa Xuân 2022' },
    { href: 'voied.html', text: 'Mùa Hạ 2022' },
];
const MenuItems = () => {
    return (
        <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'block' } }}>
            <MenuDropDown contents={topAnime} className="topAnime">
                <Button sx={{ color: '#fff', '&:hover': { backgroundColor: 'transparent' } }}>
                    TOP ANIME <KeyboardArrowDownIcon sx={{ color: '#b5e745' }} />
                </Button>
            </MenuDropDown>
            <MenuDropDown contents={theLoai} className="theLoai">
                <Button sx={{ color: '#fff', '&:hover': { backgroundColor: 'transparent' } }}>
                    THỂ LOẠI <KeyboardArrowDownIcon sx={{ color: '#b5e745' }} />
                </Button>
            </MenuDropDown>
            <MenuDropDown contents={seasion} className="seasion">
                <Button sx={{ color: '#fff', '&:hover': { backgroundColor: 'transparent' } }}>
                    SEASION <KeyboardArrowDownIcon sx={{ color: '#b5e745' }} />
                </Button>
            </MenuDropDown>

            <Button component={Link} href="/" sx={{ color: '#fff', '&:hover': { backgroundColor: 'transparent' } }}>
                THƯ VIỆN
            </Button>
            <Button component={Link} href="/" sx={{ color: '#fff', '&:hover': { backgroundColor: 'transparent' } }}>
                LỊCH CHIẾU
            </Button>
        </Box>
    );
};

export default MenuItems;
