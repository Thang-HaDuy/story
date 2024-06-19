import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Link from 'next/link';
import SuggestedTagItem from './SuggestedTagItem';

export interface ITag {
    tag: string;
}

const SuggestedTagList = () => {
    const tags: string[] = [
        ' List anime của studio TOEI ANIMATION',
        ' List anime của studio MAPPA',
        'List anime thể loại Action -Romance',
        'List anime thể loại Action - Comedy',
        'List anime Ghibli',
    ];
    return (
        <Box>
            {tags.map((tag, index) => (
                <SuggestedTagItem key={index} tag={tag} />
            ))}
            {/* <Box
                component={Link}
                href="/login"
                sx={{ textDecoration: 'none', display: 'inline-block', margin: '2px 10px' }}
            >

                <Typography
                    sx={{
                        padding: '3px 7px',
                        borderRadius: '3px',
                        color: '#fff',
                        backgroundColor: 'rgba(0,0,0,.26)',
                        fontSize: '13px',
                        fontWeight: '300',
                        borderLeft: '5px solid #c33838',
                    }}
                >
                    List anime thể loại Action - Comedy
                </Typography>
            </Box> */}
        </Box>
    );
};

export default SuggestedTagList;
