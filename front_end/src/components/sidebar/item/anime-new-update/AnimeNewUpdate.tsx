import Box from '@mui/material/Box';
import TitleSidebar from '@/components/sidebar/item/TitleSidebar';
import Link from 'next/link';
import Typography from '@mui/material/Typography';
import ItemAnime from './ItemAnime';

export interface INewAnime {
    name: string;
    episode: number;
}

const AnimeNewUpdate = () => {
    const newAnime: INewAnime[] = [
        {
            name: 'Già Thiên',
            episode: 12,
        },
        {
            name: 'Già ThiênINewAnimeINewAnime',
            episode: 12,
        },
        {
            name: 'Già Thiê INewAnime INewAnime INewAnimen',
            episode: 12,
        },
        {
            name: 'Già Thiên',
            episode: 12,
        },
        {
            name: 'Già Thiên',
            episode: 12,
        },
        {
            name: 'Già Thiên',
            episode: 12,
        },
        {
            name: 'Già Thiên',
            episode: 12,
        },
        {
            name: 'Già Thiên',
            episode: 12,
        },
        {
            name: 'Già Thiên',
            episode: 12,
        },
        {
            name: 'Già Thiên',
            episode: 12,
        },
    ];

    return (
        <Box
            sx={{
                width: '100%',
                padding: '10px',
                backgroundColor: '#181d1f',
                marginBottom: '20px',
                borderRadius: '3px',
            }}
        >
            <TitleSidebar content={'ANIME MỚI CẬP NHẬT'}>
                <></>
            </TitleSidebar>
            <Box>
                {newAnime.map((anime, index) => (
                    <ItemAnime key={index} item={anime} />
                ))}
                <Box
                    component={Link}
                    href="/login"
                    sx={{
                        textDecoration: 'none',
                        paddingY: '6px',
                    }}
                >
                    <Typography
                        sx={{
                            fontSize: '13px',
                            fontWeight: '300',
                            padding: '7px',
                            color: '#ccc',
                            '&:hover': { color: '#fff', borderLeft: '5px solid #be3232' },
                            borderBottom: '1px solid #171515',
                        }}
                    >
                        Xem Thêm...
                    </Typography>
                </Box>
            </Box>
        </Box>
    );
};

export default AnimeNewUpdate;
